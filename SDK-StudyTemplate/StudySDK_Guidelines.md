# VisualHFT Study SDK guide

This guide accompanies the working [Study Plugin Template](README.md). Use the template and current base classes as the source of truth for the plugin API.

## Purpose

A study derives from `BasePluginStudy`. It observes shared market data, calculates a metric, and publishes `BaseStudyModel` values for the dashboard and trigger engine.

## Build from the template

1. Copy `SDK-StudyTemplate` to `VisualHFT.Plugins/Studies.<YourStudy>`.
2. Rename the project, namespace, settings classes, and `TemplateStudyPlugin`.
3. Update the plugin identity fields and tile labels.
4. Add settings for the calculation and expose them in the settings view.
5. Add the project as a `ProjectReference` in `VisualHFT.csproj`.

The host scans the directory containing `VisualHFT.exe` for plugin DLLs. A source project reference is the normal way to put the compiled study beside the application.

## Data flow

The template follows this sequence:

```text
OrderBook callback → OrderBookSnapshot → HelperCustomQueue → calculation → AddCalculation
```

In `StartAsync()`, subscribe to `HelperOrderBook.Instance`. In the callback, filter the order book by the configured provider and symbol, then create an `OrderBookSnapshot` and enqueue it. The calculation runs in `QUEUE_onRead(OrderBookSnapshot)` outside the incoming market-data callback.

`OrderBook` instances are mutable and may be pooled. Do not retain one after its callback. Use a snapshot and return its resources with `Dispose()` when processing ends.

```csharp
private void QUEUE_onRead(OrderBookSnapshot snapshot)
{
    try
    {
        double value = CalculateMetric(snapshot);

        AddCalculation(new BaseStudyModel
        {
            Value = (decimal)value,
            Timestamp = HelperTimeProvider.Now,
            MarketMidPrice = 0
        });
    }
    finally
    {
        snapshot.Dispose();
    }
}
```

There is no `Calculate(List<BookItem>)` override in the current study base class. Publish results through `AddCalculation(...)`. It handles the calculation pipeline and invokes its calculated event.

## Aggregation and alerts

Override `onDataAggregation(List<BaseStudyModel>, BaseStudyModel, int)` when the default aggregation does not match the metric. The template implements last-value-wins behavior.

Raise `OnAlertTriggered?.Invoke(this, value)` only when the study's alert condition is met. Keep threshold and other user-facing values in the settings model.

## Settings and UI

`LoadSettings()`, `SaveSettings()`, and `InitializeDefaultSettings()` are required base-class overrides. Keep `GetUISettings()` aligned with the settings model so a user can configure the provider, symbol, aggregation, and study-specific parameters.

## Required license level

The plugin manager reads `IPlugin.RequiredLicenseLevel` when it loads a DLL. `BasePluginStudy` defaults to `eLicenseLevel.COMMUNITY`. Keep that default, or make it explicit, for a study intended for this public repository.

```csharp
public override eLicenseLevel RequiredLicenseLevel => eLicenseLevel.COMMUNITY;
```

## Before submitting

- Verify provider and symbol filtering with representative market data.
- Return every snapshot to its pool, including error paths.
- Keep market-data callbacks short and avoid blocking work inside them.
- Confirm that published values have the correct timestamp and metric value.
- Build the study and verify it appears when the host starts.
- Add focused tests for the calculation and its edge cases.
