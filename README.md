# MyGlobalTool

## Overview

This is a Minimal Reproducible Example (MRE) of the inability to pack tools into a global tool using the [PackageDownload](https://learn.microsoft.com/en-us/nuget/consume-packages/packagedownload-functionality) feature. I believe this is a recurrence of an issue previously addressed multiple times in 2020:

- Missing tools from PackageDownload when publishing as global tool [#394](https://github.com/nuke-build/nuke/issues/394)
- ToolPathResolver does not take dependencies into account [#396](https://github.com/nuke-build/nuke/issues/396)
- Nuke isn't packing referenced tools with global tool [#437](https://github.com/nuke-build/nuke/issues/437)

## Instructions

1. Navigate to the root directory of the solution in PowerShell
2. Enter command `nuke` to build the project successfully using `Build.cs` from the `_build` project
3. Enter command `dotnet pack` to package the Nuke build as a global tool
4. Enter command `dotnet tool install --global --add-source .\artifacts MyGlobalTool` to install the global tool
5. Enter command `my-command` to execute the build from the global tool and generate the following error:

```
Could not inject value for Build.GitVersion
System.Exception: Missing package reference/download.
Run one of the following commands:
  - nuke :add-package GitVersion.Tool --version 5.12.0
  - nuke :add-package GitVersion.CommandLine --version 5.12.0
 ---> System.ArgumentException: Could not find package 'GitVersion.Tool' or 'GitVersion.CommandLine'
```

6. Enter command `dotnet tool uninstall --global MyGlobalTool` to remove the global tool

## Version Info

This issue has been verified using the following Nuke versions:

- 7.0.5
- 8.0.0 (used in this MRE)

This issue has been confirmed to NOT affect the following versions:

- 5.2.1
