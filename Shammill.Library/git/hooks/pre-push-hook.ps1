$thisBranchVersionString = (Get-Content .\version.txt)
if(!$thisBranchVersionString)
{
    Write-Host "Failed to push changes. The file './version.txt' could not be found"
    exit 1
}

$expectedBranchVersionString = (Get-Content .\.git\hooks\version.txt)
if(!$expectedBranchVersionString)
{
    Write-Host "Failed to push changes. The file './.git/hooks/version.txt' could not be found"
    exit 1
}

try
{
    $thisBranchVersion = New-Object System.Version($thisBranchVersionString)
}
catch
{
    Write-Host "Failed to read the current branch version from './version.txt'"
    exit 1
}
   
try
{
    $expectedBranchVersion = New-Object System.Version($expectedBranchVersionString)
}
catch
{
    Write-Host "Failed to read the expected branch version from './.git/hooks/version.txt'"
    exit 1
}

$result = $thisBranchVersion.CompareTo($expectedBranchVersion)

if($result -ne 0)
{
    Write-Host "The current branch version does not equal the expected branch version. You may have performed a back merge."
    exit 1
}

$lastVersionSearchString = $thisBranchVersionString + ".*"
$lastVersionNumber = (git tag --list $lastVersionSearchString | foreach($_){echo $_.split(".")[3]} | measure -max).Maximum + 1
$lastVersionString = $thisBranchVersionString + "." + $lastVersionNumber
$color = "magenta";
echo "   ___   __  __   ____   __ __	";
echo "  / _ \ / / / /  / __/  / // /	";
echo " / ___// /_/ /  _\ \   / _  / 	";
echo "/_/    \____/  /___/  /_//_/  	";
                              
                                                  
Write-Host $("You are checking into v"+ $lastVersionString) -foregroundcolor cyan
exit 0