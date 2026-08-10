# Changelog

The early project history below was migrated from the README. These entries are dated rather than tagged releases.

## 2025-03-16

### Enhancements

#### New plugins

- Bitstamp
- Gemini
- Kraken
- KuCoin

#### Plugin improvements

- Enhanced plugin lifecycle handling so each plugin can reconnect and stop without affecting the core application.
- Improved plugin error handling.
- Added a module for exceptions and notifications from plugins and the core application.

#### Performance improvements

- Incorporated custom queues that improved performance and throughput by 40%.
- Implemented custom object pools to improve memory allocation behavior.
- Reorganised data structures and code for better performance and memory handling.
- Optimised order-book data structures for faster lookups and updates.

For details, see [pull request #41](https://github.com/visualHFT/VisualHFT/pull/41) and [pull request #36](https://github.com/visualHFT/VisualHFT/pull/36).

## 2024-06-26

### Performance improvements

- Incorporated custom queues that improved performance and throughput by 40%.
- Implemented custom object pools to improve memory allocation behavior.

### Limit order book

- Reorganised data structures and code for better performance and memory handling.
- Optimised order-book data structures for faster lookups and updates.

### Plugins

- Improved plugin lifecycle handling, including reconnection and stopping behavior.
- Enhanced error handling within plugins.

### Notification center

- Added a module for exceptions and notifications from plugins and the core application.
- Improved the notification user experience.

### Code cleanup

- Removed unused third-party packages and modules.
- Refactored the core to remove unnecessary database access, with plugins handling it where needed.

For details, see [pull request #36](https://github.com/visualHFT/VisualHFT/pull/36).

## 2023-10-27

### Enhancements

- Reworked the plugin architecture to make extensions easier to add.
- Improved performance by 200% through event and queue refactoring.

## 2023-10-19

### Enhancements

- Introduced object pooling to reduce allocations in `ProcessBufferedTrades` by reusing `Trade` and `OrderBook` objects.
- Replaced `Task.Delay(0)` with more efficient mechanisms such as `ManualResetEventSlim` or `BlockingCollection` for high-frequency data processing.
- Added a `CopyTo` method to copy data between objects efficiently and support object reuse.
- Replaced `Queue<IBinanceTrade>` with `BlockingCollection<IBinanceTrade>` for thread-safe data processing.
- Used `BlockingCollection<T>` methods including `Take` and `GetConsumingEnumerable` to process data across threads.

## 2023-10-02

### New features

### New features

- Added the plugin system for modular extension and customisation.
- Added sample Binance and Bitfinex connectors.
- Added a plugin manager UI for loading, unloading, starting, stopping, and configuring plugins.
- Added symbol normalisation for cross-venue analysis.
- Added a dynamic plugin settings UI.
- Added performance improvements through data-structure and multithreading work.

### Enhancements

- Improved error handling for plugins, including logging and UI reporting based on severity.
- Refined plugin base classes to provide more behavior out of the box.
- Added tooltips for symbol normalisation.
- Refactored code for maintainability, readability, and performance.

## 2023-09-22

### Enhancements

- Reorganised project classes and separated model and view-model concerns.
- Added custom collections and caching capability.
- Improved UI updates and memory usage.
- Prepared the architecture for independent plugins.
- Added dashboard tiles and real-time charts for VPIN, LOB Imbalance, Trade-to-Trade Ratio, Order-to-Trade Ratio, Market Resilience, and Market Resilience Bias.
- Added a multi-venue price chart.
- Updated the framework to .NET 7.0 at that time.
