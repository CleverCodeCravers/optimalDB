Param(
	[string]$connectionString,
	[string]$schema,
	[string]$objectName
)

Write-Host "Heyy! I am Script 3!"

Write-Host "You have called me using the following parameters:"
Write-Host "ConnectionString: $connectionString"
Write-Host "Schema: $schema"
Write-Host "ObjectName: $objectName"