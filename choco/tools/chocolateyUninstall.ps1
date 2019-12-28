$ErrorActionPreference = 'Stop';

Remove-Item "$HOME\Desktop\Screen Ruler.lnk"
Remove-Item "$([Environment]::GetFolderPath('CommonStartMenu'))\Programs\Bluegrams\Screen Ruler.lnk"
