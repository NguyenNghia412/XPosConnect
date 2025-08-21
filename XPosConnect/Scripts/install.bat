@echo off
setlocal

:: Get current directory (where the bat is)
set CURR_DIR=%~dp0

:: Go one folder up (remove last backslash + folder name)
for %%I in ("%CURR_DIR%..") do set PARENT_DIR=%%~fI

:: Build full path to exe
set EXE_PATH=%PARENT_DIR%\XPosConnect.exe

echo -----------------------------------
echo Installing Windows Service: XPosConnectService
echo Path: %EXE_PATH%
echo -----------------------------------

:: Create the service
sc create XPosConnectService binPath= "%EXE_PATH%" start= auto

:: Start the service right away (optional)
sc start XPosConnectService

pause
endlocal
