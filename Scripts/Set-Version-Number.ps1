Param(
    [string]$NewVersion
)

Set-Location $PSScriptRoot

Set-Location ..\Source\optimalDb\optimalDb.BL\AutoUpdates

$versionInformation = Get-Content VersionInformation.cs -Raw -Encoding UTF8
$versionInformation = $versionInformation.Replace('$$VERSION$$', $NewVersion)

$versionInformation | Set-Content VersionInformation.cs -Encoding UTF8