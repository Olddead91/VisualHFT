# Contributing to VisualHFT

First off, thanks for taking the time to contribute!


Welcome! Whether you're here to fix a bug, propose a new feature, or build something major — thank you.

We’re building VisualHFT to make real-time market microstructure visible, explainable, and actionable.

This repo is open for contributions, but we also offer a high-trust, high-responsibility equity track for long-term builders. More on that below.

## Quick Start
1. Fork the repo
2. Clone locally and follow setup in /docs
3. Open an issue if you're unsure where to start
4. Submit a clean pull request with context and motivation
5. Be kind. Stay async. Respect the product’s direction.

## Types of Contributions

| Type | Examples |
|------|----------|
| **Minor Fixes** | Bug fixes, README clarifications, refactors |
| **Infra Improvements** | Latency handling, connectors (e.g., Kafka, FIX, ITCH) |
| **Quant Signals** | New microstructure indicators, replay features |
| **Visual Modules** | UI improvements, execution slippage layers, etc. |
| **Feature Proposals** | Open an issue with your idea + motivation |


---

## 🧠 Partner Quant Program (Equity)

If you're here to **build something substantial** — and stay involved — consider applying to the [Partner Quant Program](PartnerQuantProgram.md).

This program grants real **equity in VisualHFT** for those who:
- Build production-grade modules
- Stick around to evolve + maintain them
- Operate like pre-funding technical cofounders

> ⚠️ This is not a paid role. Equity only.
> Cash roles may become available once the company is funded or profitable.🔗 **[Learn more and apply →](PartnerQuantProgram.md)**

---



## Issues

Issues are created [here](https://github.com/silahian/VisualHFT/issues/).



## Pull Requests

Pull Requests are the way concrete changes are made to the code, documentation,
dependencies, and tools contained in the `silahian/VisualHFT` repository.

### Setting up your local environment
#### Step 1: Fork

Fork the project on GitHub and clone your fork locally.
```
git clone git@github.com:username/VisualHFT.git
cd VisualHFT
git remote add upstream https://github.com/silahian/VisualHFT.git
git fetch upstream
```
  #### Step 2: Build
  Open up the `VisualHFT.sln` file with [Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/community/). Press `F6` to build or from the menu `Build/ Build Solution` 
  #### Step 3: Branch
To keep your development environment organized, create local branches to hold your work. These should be branched directly off of the main branch.
```
git checkout -b my-branch -t upstream/master
```
### Making Changes
#### Step 4: Code
Do the work!
#### Step 5: Commit
It is recommended to keep your changes grouped logically within individual commits. Many contributors find it easier to review changes that are split across multiple commits. There is no limit to the number of commits in a pull request.

Use the `Git Changes` tab in Visual Studio to make your commits. Visual Studio does the heavy lifting of adding new files and all changes to the commit. 
##### Commit message guidelines
A good commit message should describe what changed and why.
Common prefixes:

* fix: A bug fix
* feat: A new feature
* docs: Documentation changes
* test: Adding missing tests or correcting existing tests
* build: Changes that affect the build system
* ci: Changes to our CI configuration files and scripts
* perf: A code change that improves performance
* refactor: A code change that neither fixes a bug nor adds a feature
* style: Changes that do not affect the meaning of the code (linting)

#### Step 6: Rebase
Once you have committed your changes, it is a good idea to use `git rebase` (not `git merge`) to synchronize your work with the main repository.
```
git fetch upstream
git rebase upstream/master
```
#### Step 7: Test
Test your code by ensuring the application builds successfully and completes the requirements to the best of your ability. 

#### Step 8: Push
Once your commits are ready to go begin the process of opening a pull request by pushing your working branch to your fork on GitHub.

```
git push origin my-branch
```
#### Step 9: Opening the Pull Request
From within GitHub, navigate to your forked repository and press the button to open a pull request.

#### Step 10: Discuss and Update
You will probably get feedback or requests for changes to your pull request. This is a big part of the submission process so don't be discouraged! Some contributors may sign off on the pull request right away. Others may have detailed comments or feedback. This is a necessary part of the process in order to evaluate whether the changes are correct and necessary.

To make changes to an existing pull request, make the changes to your local branch, add a new commit with those changes, and push those to your fork. GitHub will automatically update the pull request.


### Congratulations and thanks for your contribution!

## Style Guides

TODO
