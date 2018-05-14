$ErrorActionPreference = "Stop"
$error.clear()

# valid versions are [2.0, 3.5, 4.0]
$dotNetVersion = "4.0"
$regKey = "HKLM:\software\Microsoft\MSBuild\ToolsVersions\$dotNetVersion"
$regProperty = "MSBuildToolsPath"

$msAspViewsCompiler = join-path -path (Get-ItemProperty $regKey).$regProperty -childpath "aspnet_compiler.exe"

#&$msAspViewsCompiler -p ApplicationName -v aspprecompile -x /aspprecompile/Reports/crystalreportviewers -errorstack

$argumentList = @("-p ApplicationName", "-v aspprecompile", "-x /aspprecompile/Reports/crystalreportviewers", "-errorstack")

$process = start-process -filepath $msAspViewsCompiler -argumentlist $argumentList -wait -nonewwindow -passthru #-RedirectStandardOutput $nUnitLog -RedirectStandardError $nUnitErrorLog

exit $process.ExitCode