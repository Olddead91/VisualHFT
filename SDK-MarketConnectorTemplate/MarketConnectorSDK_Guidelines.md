# VisualHFT Market Connector SDK guide

This guide accompanies the working [Market Connector Template](README.md). Use the template as the source of truth for the current API shape.

## Purpose

A market connector derives from `BasePluginDataRetriever`. It connects to a venue, maps venue symbols to VisualHFT symbols, and publishes `OrderBook`, `Trade`, and optional order data with `RaiseOnDataReceived(...)`.

## Build from the template

1. Copy `SDK-MarketConnectorTemplate` to `VisualHFT.Plugins/MarketConnectors.<YourExchange>`.
2. Rename the project, namespace, settings classes, and `TemplateExchangePlugin`.
3. Set a unique provider ID and provider name in `InitializeDefaultSettings()`.
4. Add the exchange client package or your own transport code to the project.
5. Add the new project as a `ProjectReference` in `VisualHFT.csproj`.

The host scans the directory containing `VisualHFT.exe` for plugin DLLs. A source project reference is the normal way to place a connector there. No separate plugin directory or registration call is required.

## Lifecycle

The template separates `StartAsync()` from `InternalStartAsync()`.

- In the constructor, call `SetReconnectionAction(InternalStartAsync)`.
- In `StartAsync()`, publish `eSESSIONSTATUS.CONNECTING`, set `Status` to `STARTING`, then call `InternalStartAsync()`.
- In `InternalStartAsync()`, open subscriptions and, after they are live, publish `eSESSIONSTATUS.CONNECTED` and set `Status` to `STARTED`.
- In `StopAsync()`, unsubscribe and dispose clients, publish an empty order-book list if required, publish `eSESSIONSTATUS.DISCONNECTED`, then call `base.StopAsync()`.
- On a connection failure, call `HandleConnectionLost(reason, exception)`. The base class manages coalescing and retry behavior through the action registered above.

Use provider updates through the existing data path:

```csharp
RaiseOnDataReceived(GetProviderModel(eSESSIONSTATUS.CONNECTING));
RaiseOnDataReceived(GetProviderModel(eSESSIONSTATUS.CONNECTED));
RaiseOnDataReceived(GetProviderModel(eSESSIONSTATUS.DISCONNECTED));
```

`RaiseOnProviderStatusChanged` and `ProviderStatus` are not current connector APIs.

## Symbols

The settings template accepts either a raw symbol or a raw and normalised pair:

```text
BTCUSDT
BTCUSDT(BTC/USD)
```

Call `ParseSymbols(...)` after loading or changing settings. Use `GetAllNonNormalizedSymbols()` when subscribing to the venue and `GetNormalizedSymbol(rawSymbol)` when publishing market data.

## Publishing data

Build VisualHFT models in your exchange callbacks and publish them with the overload that matches the model.

```csharp
var trade = new Trade
{
    ProviderId = _settings.Provider.ProviderID,
    ProviderName = _settings.Provider.ProviderName,
    Symbol = normalizedSymbol,
    Price = price,
    Size = size,
    IsBuy = isBuy,
    Timestamp = DateTime.UtcNow
};

RaiseOnDataReceived(trade);
```

For order books, keep one `OrderBook` per symbol, apply deltas with `AddOrUpdateLevel(...)` and `DeleteLevel(...)`, then publish the updated book. See the existing Bitfinex, Binance, Kraken, and Coinbase connectors for concrete exchange-specific patterns.

Do not block the exchange callback while doing network, disk, or UI work. Keep symbol precision from the venue data rather than hard-coding it.

## Settings and UI

`LoadSettings()`, `SaveSettings()`, and `InitializeDefaultSettings()` are required base-class overrides. The template also supplies a WPF settings view and view model. Keep secrets out of source control and validate user-entered settings before starting a connection.

## Required license level

The plugin manager reads `IPlugin.RequiredLicenseLevel` when loading a DLL. `BasePluginDataRetriever` defaults to `eLicenseLevel.COMMUNITY`. Keep that default, or make it explicit, for a connector intended for this public repository.

```csharp
public override eLicenseLevel RequiredLicenseLevel => eLicenseLevel.COMMUNITY;
```

## Before submitting

- Verify that the provider transitions through connecting, connected, and disconnected states.
- Test every configured raw-to-normalised symbol mapping.
- Confirm that order books and trades carry the expected provider and normalised symbol.
- Build the connector and verify it appears when the host starts.
- Add focused tests where the connector has testable parsing or state logic.
