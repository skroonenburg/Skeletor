$configuration = "Debug"
#$configuration = "Release"

# Grab the first connection string in the web projects web.config file
$webConfigFile = [xml](Get-Content "..\src\Skeletor.Web.UI\Web.config")
$first = ([Array]$webConfigFile.configuration.connectionStrings.add)[0]

# Write-Host "First conn string: $($first.name) $($first.connectionString)"

# Run the migrator
$assembly = "..\src\Skeletor.DatabaseMigrations\bin\$configuration\Skeletor.DatabaseMigrations.dll" 
$migrator = "..\tools\FluentMigrator\migrate.exe"
$now = Get-Date -f "yyyyMMddhhmmss"
& $migrator --conn ""$($first.connectionString)"" --provider sqlserver2008 --assembly ""$($assembly)"" --task migrate --output --outputFilename migrated-$($now).sql --profile ""Debug""

Write-Host " "
Read-Host 