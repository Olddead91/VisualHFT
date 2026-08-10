# Troubleshooting

## The solution cannot find OxyPlot projects

`VisualHFT.csproj` uses sibling project references to the VisualHFT OxyPlot fork. Clone `https://github.com/visualHFT/oxyplot.git` beside this repository, as shown in [Getting started](getting-started.md), then reload the solution.

## A plugin does not appear in VisualHFT

VisualHFT scans the directory containing `VisualHFT.exe` for plugin DLLs. Add the plugin project as a `ProjectReference` in `VisualHFT.csproj`, rebuild the solution, and verify that its output is next to the application executable. See [Extending VisualHFT](extending/README.md).

## A provider shows no market data

Confirm that the connector is started, that its provider status is connected, and that the selected symbol matches the connector's configured normalised symbol. Check the connector settings for the expected raw-to-normalised symbol mapping.

## I need help

- Ask the community in [VisualHFT Discord](https://visualhft.com/discord).
- Discuss ideas in [GitHub Discussions](https://github.com/visualHFT/VisualHFT/discussions).
- Report reproducible bugs in [GitHub Issues](https://github.com/visualHFT/VisualHFT/issues).
