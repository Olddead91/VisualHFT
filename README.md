<p align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="assets/brand/visualhft-wordmark-dark.png">
    <source media="(prefers-color-scheme: light)" srcset="assets/brand/visualhft-wordmark-light.png">
    <img alt="VisualHFT" src="assets/brand/visualhft-wordmark-light.png" width="260">
  </picture>
</p>

<p align="center">
  An open-source desktop application for real-time market microstructure analysis.
</p>

<p align="center">
  <a href="https://visualhft.com">Website</a> ·
  <a href="docs/README.md">Documentation</a> ·
  <a href="https://visualhft.com/discord">Discord</a> ·
  <a href="https://github.com/visualHFT/VisualHFT/discussions">Discussions</a>
</p>

<p align="center">
  <a href="LICENSE.txt"><img alt="License: Apache-2.0" src="https://img.shields.io/badge/License-Apache--2.0-0D7C66?style=flat-square"></a>
  <a href="https://dotnet.microsoft.com/download/dotnet/10.0"><img alt=".NET 10" src="https://img.shields.io/badge/.NET-10-512BD4?style=flat-square"></a>
  <img alt="Platform: Windows" src="https://img.shields.io/badge/platform-Windows-0078D4?style=flat-square">
  <a href="https://visualhft.com/discord"><img alt="Community: Discord" src="https://img.shields.io/badge/community-Discord-5865F2?style=flat-square&logo=discord&logoColor=white"></a>
</p>

![VisualHFT dashboard showing real-time Level 2 order book, liquidity, and market microstructure analytics](docImages/visualhft-hero-L2.gif)

<p align="center">
  <a href="#quickstart">Quickstart</a> ·
  <a href="docs/architecture.md">Architecture</a> ·
  <a href="#extend-visualhft">Extend</a> ·
  <a href="CHANGELOG.md">Changelog</a> ·
  <a href="CONTRIBUTING.md">Contributing</a>
</p>

## What it does

VisualHFT brings live order books and trades from supported venues into one desktop view. It helps traders, quants, and researchers examine depth, liquidity, order flow, and market resilience while conditions are changing.

| Live order book | Built-in study |
| --- | --- |
| ![Full depth order-book view updating with live bid, ask, trade, and study data](docImages/LOB_fulldepth.gif) | ![LOB Imbalance study visualising changes in order-book pressure](docImages/LOB_imbalances_2.gif) |

## Quickstart

### Prerequisites

- Windows, the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0), and Visual Studio.
- The VisualHFT OxyPlot fork. Place both repositories in the same parent folder.

```powershell
# Both repositories must sit in the same parent folder.
git clone https://github.com/visualHFT/oxyplot.git
git clone https://github.com/visualHFT/VisualHFT.git
```

Open `VisualHFT/VisualHFT.sln` in Visual Studio and build the solution. Set `VisualHFT` as the startup project and press <kbd>F5</kbd>. The Dashboard opens first. Select an available provider and a normalised symbol such as `BTC/USD` in the order-book panel.

Need help with setup? See [Troubleshooting](docs/troubleshooting.md) or ask in [Discord](https://visualhft.com/discord).

## Included in this repository

| Area | Included examples |
| --- | --- |
| Market data connectors | Binance, Bitfinex, Bitstamp, Coinbase, Gemini, Kraken, KuCoin, and a generic WebSocket connector |
| Built-in studies | VPIN, LOB Imbalance, Market Resilience, and Order-to-Trade Ratio |
| Extensibility | Templates for additional market connectors and market-microstructure studies |

Connectors normalise live Level 2 order-book and trade updates for the dashboard and study plugins. Study outputs can also drive trigger conditions that send alerts to the user interface or configured REST endpoints.

## Extend VisualHFT

VisualHFT has templates and guides for two extension points:

- [Market connector template](SDK-MarketConnectorTemplate/) for a new market-data source.
- [Study template](SDK-StudyTemplate/) for a custom market-microstructure calculation.

Read the [architecture overview](docs/architecture.md) before extending the application. Use the matching template and guide before distributing a plugin.

## Community and updates

Ask questions in [Discord](https://visualhft.com/discord) or [GitHub Discussions](https://github.com/visualHFT/VisualHFT/discussions). Report bugs and feature requests through [GitHub Issues](https://github.com/visualHFT/VisualHFT/issues).

Follow [VisualHFT Connect](https://visualhft.com/connect), [LinkedIn](https://www.linkedin.com/company/visualhft/), [X](https://x.com/visualHFT), and [Substack](https://visualhft.substack.com) for research and project updates. See [CONTRIBUTING.md](CONTRIBUTING.md) to contribute code or documentation.

## Roadmap and changes

See the [project roadmap](https://visualhft.com/#roadmap) for planned work and [CHANGELOG.md](CHANGELOG.md) for dated changes. This README describes functionality included in the public repository today.

## License

VisualHFT is licensed under the [Apache License 2.0](LICENSE.txt).
