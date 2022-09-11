Param(
	[string]$connectionString,
	[string]$schema,
	[string]$objectName
)

Write-Host "You cannot see this output"

Write-Host "###OUTPUTSTARTSHERE###"

Write-Host "This is the first line that is shown to the user!"
Write-Host ""
Write-Host "You have called me using the following parameters:"
Write-Host "ConnectionString: $connectionString"
Write-Host "Schema: $schema"
Write-Host "ObjectName: $objectName"