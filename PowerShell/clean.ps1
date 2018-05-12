Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { if ($_.fullname -like '*References*') { Write-Output "Skipping $_.fullname" } else { remove-item $_.fullname -Force -Recurse } }
if (Test-Path  .\Testbin) {
Get-ChildItem .\Testbin |  foreach($_) { Remove-Item $_.fullname -Force -Recurse }
}