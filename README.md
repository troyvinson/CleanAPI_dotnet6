# CleanAPI_dotnet6

## Introduction
A clean architecture Web API project in .NET 6

## Environment

Install                             | Version    
------------------------------------|------------
.NET                                | 6
PowerShell                          | 7.x
Visual Studio                       | VS 2022
EF Core Tools                       | latest
SQL Server Express LocalDB          | 2019

Sources:
*   [.NET](https://dotnet.microsoft.com/download/dotnet)
*   [PowerShell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-windows)
*   [Visual Studio](https://visualstudio.microsoft.com/downloads/)
*   [SQL Server Express LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

>*SQL Server Express Note:* As of 5/1/2023 Microsoft recommends Visual Studio 2019 and 2022 customers should install SQL Server Express 2019.  
  
---  
  
## Getting Started

**Environment**  
1.  Install Visual Studio Workloads (ASP.NET and web development)
1.  Install PowerShell 7.x.
1.  Install .NET 6.
1.  Install SQL Server Express


**Application** 
```powershell
# Clone source
$ErrorActionPreference = 'Stop'
cd "c:/src"
git clone https://github.com/troyvinson/CleanAPI_dotnet6.git
cd CleanAPI_dotnet6

# Build app
build/build.ps1

# Run SQL migrations
cd package/Migrations/DataMigrations
./efbundle.exe
cd ../../../

# Run IntegrationTests (Optional)
dotnet test ./tests/IntegrationTests
```

## Pipeline
The pipeline should run the build script with the -CI option.

```powershell
./build/build.ps1 -CI
```

## Migrations
Example:

```powershell
dotnet ef migrations add InitialCreate --project DataMigrations --startup-project ApiServer --context RepositoryContext
```

## When to run the build script
The build script simulates what the CI server will do, and is intended to catch build errors before they get to the server. The script should be run before the "final" PR commit. That is:

1.  Before pushing the final feature branch, AND/OR
1.  Before pushing to the mainline branch
