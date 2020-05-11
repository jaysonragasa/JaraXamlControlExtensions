for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (_UpgradeReport_Files,Backup) do @if exist "%%d" rd /s/q "%%d"
del UpgradeLog*.htm
del UpgradeLog*.XML
rmdir ".vs" /S /Q
rmdir "%localappdata%\temp\Temporary ASP.NET Files\vs" /S /Q
rmdir "%localappdata%\temp\Temporary ASP.NET Files\root" /S /Q