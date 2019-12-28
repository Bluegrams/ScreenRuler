$ErrorActionPreference = 'Stop';
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"


$archive = Join-Path $toolsDir "screenruler.zip"
Get-ChocolateyUnzip -FileFullPath $archive -Destination $toolsDir -PackageName $env:ChocolateyPackageName

$targetDir = Join-Path $toolsDir "screenruler"
$target =  Join-Path $targetDir "screenruler.exe"
Install-ChocolateyShortcut -shortcutFilePath "$HOME\Desktop\Screen Ruler.lnk" -targetPath $target -workingDirectory $targetDir
Install-ChocolateyShortcut -shortcutFilePath "$([Environment]::GetFolderPath('CommonStartMenu'))\Programs\Bluegrams\Screen Ruler.lnk" -targetPath $target -workingDirectory $targetDir

New-Item -Path "$target.gui" -ItemType File -Force | Out-Null
