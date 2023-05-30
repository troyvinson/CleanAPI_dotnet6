[CmdletBinding()]
Param (
    # Convention is running from a root/build folder
    # User can pass in path relative to where calling from,
    # e.g. if in repo root:
    # . build/build.ps1 package
    [String]$PackageDirectory = (Join-Path $PSScriptRoot '../package'),
    [switch]$CI, 
    [switch]$Clean,
    [switch]$NoTest,
    [switch]$TestOnly
    )

# ===== INIT =====
$StartDirectory = Get-Location
# Immediately exit on any error
$ErrorActionPreference = 'Stop'
# Ensure running from where script is located
Set-Location $PSScriptRoot

# ===== FUNCTIONS =====
. ./shared-functions.ps1 

function End() {
    $sw.Stop()
    Write-Host "=========================="
    Write-Host Total elapsed time: $sw.Elapsed.TotalMinutes.ToString("f") minutes -ForegroundColor Green
    Write-Host "=========================="
    Set-Location $StartDirectory
    Exit
}

function CheckForError(){
    if ($Error.Length -gt 0 -Or ($LASTEXITCODE -ne 0 -And -Not([string]::IsNullOrWhiteSpace($LASTEXITCODE)))) {
        End
    }
}

# ===== SETTINGS =====
$Title = "BUILD ALL"
$PackageDirectory = Convert-PathClean $PackageDirectory
if (-Not([System.IO.Path]::IsPathRooted($PackageDirectory))) {
	$PackageDirectory = Join-PathClean $StartDirectory $PackageDirectory
}

Write-H1 $Title
Write-H2 "SETTINGS"
Write-Message "CI                       $CI"
Write-Message "Clean                    $Clean"
Write-Message "NoTest                   $NoTest"
Write-Message "TestOnly                 $TestOnly"
Write-Message "StartDirectory           $StartDirectory"
Write-Message "PackageDirectory         $PackageDirectory"
Write-Message ""

# ===== MAIN =====
$sw = [System.Diagnostics.Stopwatch]::StartNew()

# Environment
./build-environment

# Test
if (-Not($NoTest)) {
    ./test-dotnet `
        -ProjectDirectory ../tests/UnitTests `
        -PackageDirectory $PackageDirectory `
        -CI:$CI `
        -Clean:$Clean 
}
else 
{
    Write-H1 TESTS
    Write-Message "Skipping tests with -NoTest flag"
    Write-Message ""
}

CheckForError

if ($TestOnly) {
    End
}

# Build and Package
./build-dotnet `
    -ProjectDirectory ../src/ApiServer `
    -PackageDirectory $PackageDirectory `
    -CI:$CI `
    -Clean:$Clean

CheckForError

#Initialize user-secrets
Write-H2 "INIT USER SECRETS"

# Load csproj as XML
[xml]$projectXml = Get-Content '../src/ApiServer/ApiServer.csproj'

# Check for existence of UserSecretsId element
$userSecretsId = $projectXml.Project.PropertyGroup.UserSecretsId
if ($null -ne $userSecretsId) {
    Write-Output "User secrets has been initialized for this project. UserSecretsId: $($userSecretsId)"
} else {
    Run { Set-Location ../src/ApiServer }
    Run { dotnet user-secrets init } 
    Run { dotnet user-secrets set "AzureAdB2C:Instance" "https://{your-tenant-name}.b2clogin.com" }
    Run { dotnet user-secrets set "AzureAdB2C:Domain" "<your-tenant-name>.onmicrosoft.com" }
    Run { dotnet user-secrets set "AzureAdB2C:ClientId" "<client id>" }
    Run { dotnet user-secrets set "AzureAdB2C:SignedOutCallbackPath" "/signout/B2C_1_SignUpAndSignIn" }
    Run { dotnet user-secrets set "AzureAdB2C:SignUpSignInPolicyId" "B2C_1_SignUpAndSignIn" }
    # Run { dotnet user-secrets set "AzureAdB2C:CallbackPath" "/signin-oidc" }
    # Run { dotnet user-secrets set "AzureAdB2C:ResetPasswordPolicyId" "B2C_1_PasswordReset" }
    # Run { dotnet user-secrets set "AzureAdB2C:EditProfilePolicyId" "B2C_1_ProfileEdit" }
}

# Data
./build-migrations `
    -ProjectDirectory ../src/DataMigrations `
    -StartupProjectDirectory ../src/ApiServer `
    -DbContextName RepositoryContext `
    -PackageDirectory $PackageDirectory `
    -CI:$CI `
    -Clean:$Clean `

Run {Copy-Item -Path ../src/ApiServer/nlog.config -Destination ../package/Migrations/DataMigrations }


# Exit with stats
End
