@echo off
cd ..\

Set "RepoRoot=%CD%"
Set /p ArduinoLibDir=Enter Arduino libraries folder: 

if exist "%ArduinoLibDir%\NDefs" (
	powershell -Command "& {rd -r '%ArduinoLibDir%\NDefs'}"
	echo Deleted libraries\NDefs Directory.
) else (
	echo No NDefs to delete.
)

if exist "%ArduinoLibDir%\NColor" (
	powershell -Command "& {rd -r '%ArduinoLibDir%\NColor'}"
	echo Deleted libraries\NColor Directory.
) else (
	echo No NColor to delete.
)

if exist "%ArduinoLibDir%\NFuncs" (
	powershell -Command "& {rd -r '%ArduinoLibDir%\NFuncs'}"
	echo Deleted libraries\NFuncs Directory.
) else (
	echo No NFuncs to delete.
)

if exist "%ArduinoLibDir%\NPush" (
	powershell -Command "& {rd -r '%ArduinoLibDir%\NPush'}"
	echo Deleted libraries\NPush Directory.
) else (
	echo No NPush to delete.
)

if exist "%ArduinoLibDir%\NRotary" (
	powershell -Command "& {rd -r '%ArduinoLibDir%\NRotary'}"
	echo Deleted libraries\NRotary Directory.
) else (
	echo No NRotary to delete.
)

if exist "%ArduinoLibDir%\NWire" (
	powershell -Command "& {rd -r '%ArduinoLibDir%\NWire'}"
	echo Deleted libraries\NWire Directory.
) else (
	echo No NWire to delete.
)

@echo on

echo d | xcopy /d /y /s "%RepoRoot%\NColor" "%ArduinoLibDir%\NColor"
echo d | xcopy /d /y /s "%RepoRoot%\NFuncs" "%ArduinoLibDir%\NFuncs"
echo d | xcopy /d /y /s "%RepoRoot%\NPush" "%ArduinoLibDir%\NPush"
echo d | xcopy /d /y /s "%RepoRoot%\NRotary" "%ArduinoLibDir%\NRotary"
echo d | xcopy /d /y /s "%RepoRoot%\NWire" "%ArduinoLibDir%\NWire"
echo d | xcopy /d /y /s "%RepoRoot%\NDefs" "%ArduinoLibDir%\NDefs"