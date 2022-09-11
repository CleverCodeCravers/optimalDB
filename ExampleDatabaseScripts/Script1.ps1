Param(
	[string]$connectionString,
	[string]$schema,
    [string]$database,
	[string]$objectName
)

Write-Host "Heyy! I am Script 1!"

Write-Host "You have called me using the following parameters:"
Write-Host "ConnectionString: $connectionString"
Write-Host "Schema: $schema"
Write-Host "Schema: $database"
Write-Host "ObjectName: $objectName"

