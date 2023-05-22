# CleanAPI_dotnet6

## Introduction
A clean architecture Web API project in .NET 6
  
&nbsp;  

---  
  
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
  
&nbsp;  

---  
  
## Getting Started

**Environment**  
1.  Install Visual Studio Workloads (ASP.NET and web development)  
1.  Install PowerShell 7.x.  
1.  Install .NET 6.  
1.  Install SQL Server Express  
1.  Set an environment variable for the JWT example secret key:  
    * ``` setx APISERVERSECREYKEY "some-secret-key-value" /M ```  
    * If you do not have admin access to your dev environment, leave off the "/M" to set a user-level local environment variable  
        * ``` setx APISERVERSECREYKEY "some-secret-key-value" ```  

  

**Application**  
Powershell:  
``` powershell
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

&nbsp;  

---  

## Pipeline
The pipeline should run the build script with the -CI option.

Powershell:  
``` powershell
./build/build.ps1 -CI
```

&nbsp;  

---  

## Migrations
New EF Core migrations can be run inside the project folder in PowerShell or the Visual Studio Package Manager Console window.  

Powershell:  
``` powershell
dotnet ef migrations add MigrationName --project DataMigrations --startup-project ApiServer --context RepositoryContext
```  
  
Visual Studio Package Manager Console:  
``` Add-Migration MigrationName -StartupProject ApiServer -Project DataMigrations ```  
  
&nbsp;  

---  

## When to run the build script
The build script simulates what the CI server will do, and is intended to catch build errors before they get to the server. The script should be run before the "final" PR commit. That is:

1.  Before pushing the final feature branch, AND/OR
1.  Before pushing to the mainline branch
