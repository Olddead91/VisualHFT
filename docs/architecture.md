# Architecture overview

VisualHFT is a Windows desktop application built around a shared market-data layer and independently loadable plugins.

```text
Market connector plugins
        ↓
Normalised OrderBook and Trade models
        ↓
Shared helper services
        ↓
Dashboard and study plugins
        ↓
Charts, metrics, triggers, and alerts
```

## Main components

### Desktop host

The `VisualHFT` project is the WPF desktop host. It owns the dashboard, plugin-management views, trigger configuration, and application startup.

### Shared core

`VisualHFT.Commons` contains shared models, helpers, plugin base classes, and contracts. `VisualHFT.Commons.WPF` contains reusable WPF-specific behavior.

### Market connector plugins

Connectors derive from `BasePluginDataRetriever`. They connect to a venue, map its symbols into the configured normalised form, and publish `OrderBook` and `Trade` updates with `RaiseOnDataReceived(...)`.

### Study plugins

Studies derive from `BasePluginStudy`. They subscribe to shared market data, perform their calculation away from the incoming data callback, and publish `BaseStudyModel` values with `AddCalculation(...)`.

## Plugin discovery

At startup, `PluginManager.LoadPlugins()` scans the directory that contains `VisualHFT.exe` for DLLs. It loads non-abstract types that implement `IPlugin` and that meet their declared `RequiredLicenseLevel`. There is no separate plugin folder.

For a new connector or study, start with the [extension templates](extending/README.md).

## Interactive reference

The existing [interactive architecture map](system-architecture.html) provides a visual companion to this overview.
