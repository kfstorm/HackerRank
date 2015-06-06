@echo off
setlocal ENABLEDELAYEDEXPANSION

pushd "%~dp0"
set problem=%1

if "%problem%"=="" (
    echo Need to pass problem^^! Available problems are^^:
    for /F %%i in ('dir /b src\*.cs') do (
        set sourcefile=%%i
        echo !sourcefile:~0,-3!
    )
    exit /b 1
)

if not exist bin\ mkdir bin
if not exist tmp\%problem% mkdir tmp\%problem%
echo Compiling src\%problem%.cs ...
csc src\%problem%.cs /out:bin\%problem%.exe /nologo
if !errorlevel! NEQ 0 exit /b 1

for /F %%i in ('dir /b cases\%problem%\input*.txt') do (
    set inputfile=%%i
    set suffix=!inputfile:~5!
    echo Executing program with test case %%i ...
    bin\%problem%.exe < cases\%problem%\%%i > tmp\%problem%\output!suffix!
    fc /W cases\%problem%\output!suffix! tmp\%problem%\output!suffix! 1> NUL
    if !errorlevel! NEQ 0 (
        fc /W cases\%problem%\output!suffix! tmp\%problem%\output!suffix!
        goto :OutputMismatch
    )
)

echo Test passed.

goto :EOF

:OutputMismatch
echo Output mismatch^^!
exit /b 1
