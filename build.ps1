[CmdletBinding()]
param (
    [Parameter()]
    [switch]
    $run
)
Set-Location ./vector_animation
dotnet clean
dotnet restore
dotnet workload restore
dotnet publish
Set-Location ..
if ($run) {
	electron elec.js
}
