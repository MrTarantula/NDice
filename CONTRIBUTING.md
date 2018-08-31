# Contributing

PRs are welcome. I only have a few rules:

1. Respect the style of the code (e.g. tabs, brace placement). When in doubt, `Alt+Shift+F` (VSCode) or `Ctrl+K D` (Vistual Studio)
2. Code coverage - run coverage tests (described below) and write/update applicable tests

## Environment

I develop this in VS Code. Any PRs must not include sln files or any other Visual Studio fluff. 

Recommended tools:

* [.NET Core SDK](https://www.microsoft.com/net/download)
* [VS Code](https://code.visualstudio.com/)
* [Coverage Gutters](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters) extension for VS Code
* [Coverlet](https://github.com/tonerdo/coverlet)

To help development in VS Code, some tasks are included:

* **NDice Tests** - Runs all tests in the NDice project except for the uniformity tests. Tests basic behavior and coverage.

* **NDice Uniformity Tests** - Runs all uniformity tests in NDice project. These are used to test that the dice are sufficiently random over many iterations. They may take a while to complete depending on system resources.

* **Randomizers Tests** - Runs all tests in the Ndice.Randomizers project except for uniformity tests.

* **Randomizers Uniformity Tests** - Runs all NDice.Randomizers uniformity tests.

* **NDice Coverage** - Same as **NDice Tests** but generates an lcov coverage file. Install the Coverage Gutters VS Code extension and run this task to show coverage.

* **Randomizers Coverage** - Same tests as **Randomizers Tests** but generates an lcov coverage file. Coverage Gutters will get confused if multiple files exist, so only keep the coverage file that is relevant to you.

## How to Contribute

1. Fork the repo
2. Do your thing
3. Write tests for your thing
4. Run tests as explained above
5. Create a PR
6. Wait for approval/recommendations