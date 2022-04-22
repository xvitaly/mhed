# Contributing

This document describes how you can contribute to Micro Hosts Editor. Please read it carefully.

## Issues

Feel free to open issues and [report bugs](https://github.com/xvitaly/mhed/issues/new?template=bug-report.md) or ask for [feature requests](https://github.com/xvitaly/mhed/issues/new?template=feature-request.md).

## Pull requests

 1. Create your own fork by pressing **Fork** button.
 
 2. Clone your repository
 ```bash
 git clone git@github.com:YOURNAME/mhed.git
 ```
 
 3. Create a new feature branch `new_feature` and switch to it:
 ```bash
 git checkout -b new_feature
 ```
 
 4. Commit your changes:
 ```bash
 git add . && git commit -sm "Full description of your changes"
 ```
 
 5. Add upstream as a [remote repository](https://help.github.com/articles/configuring-a-remote-for-a-fork/):
 ```bash
 git remote add upstream https://github.com/xvitaly/mhed.git
 ```
 
 6. Fetch upstream changes and [sync](https://help.github.com/articles/syncing-a-fork/) your fork's `master` branch with it:
 ```bash
 git fetch upstream
 git checkout master
 git merge upstream/master
 ```
 
 7. Rebase your feature branch to updated `master`:
 ```bash
 git checkout new_feature
 git rebase master
 ```
 
 8. Squash all your commits into a single one and open a new pull request.

### Signing off your work

Don't forget to sign off your work by using `git commit -s`:
```
Signed-off-by: Name Surname <username@example.org>
```

We cannot accept pull requests with commits without this signature.

### Some important warnings

  * Don't mix different line endings.
  * Don't upload any binary files to repository (*.dll, *.exe, etc.).
  * Don't add and upload any temporary files.
  * Use only latest version of Visual Studio 2019 IDE.
  * Don't use any libraries incompatible with [GNU GPL v3 license](../COPYING).
  * Use only NuGet to add new libraries to project.
