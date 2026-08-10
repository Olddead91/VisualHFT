# Contributing to VisualHFT

VisualHFT is built to make real-time market microstructure visible, explainable, and actionable. Contributions to code, documentation, connectors, and studies are welcome.

## Start here

1. Read [Getting started](docs/getting-started.md) and build the solution locally.
2. Check [GitHub Issues](https://github.com/visualHFT/VisualHFT/issues) and [GitHub Discussions](https://github.com/visualHFT/VisualHFT/discussions) before opening a new proposal.
3. Fork the repository and create a branch from `master`.
4. Keep each pull request focused. Explain the problem, the change, and how you validated it.

## Good contribution areas

| Area | Examples |
| --- | --- |
| Documentation | Setup fixes, examples, architecture clarification |
| Connectors | Market-data sources, symbol mapping, resilient connection handling |
| Studies | Market-microstructure indicators and visualization improvements |
| Quality | Tests, accessibility, diagnostics, and maintainability |

Use the [extension templates](docs/extending/README.md) for a new market connector or study.

## Development workflow

```powershell
git clone https://github.com/<your-account>/VisualHFT.git
cd VisualHFT
git remote add upstream https://github.com/visualHFT/VisualHFT.git
git fetch upstream
git checkout -b my-branch upstream/master
```

Before opening a pull request, build the affected project or solution and run the relevant tests. Keep commit messages clear. Common prefixes include `fix:`, `feat:`, `docs:`, `test:`, `build:`, `ci:`, `perf:`, and `refactor:`.

## Pull requests

Pull requests should include:

- A concise summary of the user or engineering problem.
- The change made and any important tradeoff.
- Validation performed, including the command when practical.
- Tests for behavior changes.

Do not change established input JSON message formats unless there is a compelling compatibility plan and community agreement. New message types are preferred when they avoid breaking existing installations.

## Community

- Ask questions in [VisualHFT Discord](https://visualhft.com/discord).
- Discuss ideas in [GitHub Discussions](https://github.com/visualHFT/VisualHFT/discussions).
- Report reproducible bugs in [GitHub Issues](https://github.com/visualHFT/VisualHFT/issues).

For long-term collaboration, see the [Partner Quant Program](PartnerQuantProgram.md).
