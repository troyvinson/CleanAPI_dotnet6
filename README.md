# CleanAPI_dotnet6  

## Introduction  

## Environment  
| Install                      | Version    |   
|------------------------------|------------|  
| PowerShell                   | 7.x        |   
| Visual Studio                | 2022       |   
| .NET                         | 6          |   
| EF Core Tools                | latest     |   
| SQL Server Express LocalDB   | 2019       |   
  
  
Sources:  
*   [PowerShell Core](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7)  
*   [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)  
*   [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
*   [SQL Server Express LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)  
*   EF Core Tools will be installed when the build script is run below

---  

## Getting Started  
Install the correct versions from above.  
  
**Install**  
1. Install PowerShell Core  
2. Install Visual Studio 2022 (ASP.NET and Web Developemnt modules)
3. SQL Server Express LocalDB

> *SQL Server Note* - As of 5/2023, the Microsoft instruction for Visual Studio 2019 and 2022 is to install SQL Server Express 2019  
  
**Build Applicaiton**  
```powershell  
$ErrorActionPreference = 'Stop'

# Clone source
cd "c:/src"
git clone https://github.com/troyvinson/CleanAPI_dotnet6.git
cd CleanAPI_dotnet6

# One-time only interactive restore
dotnet restore --interactive src/ApiServer

# Run build script
build/build.ps1

# Run database migrations
cd package/Migrations/DataMigrations
./efbundle.exe

# Run integration tests (optional)
cd ../../../
dotnet test tests/IntegrationTests
```

---  

## Pipeline
The CI pipeline should run the build script with the -CI argument.  
  
```powershell
./src/build/build.ps1 -CI
```  
  
---  


