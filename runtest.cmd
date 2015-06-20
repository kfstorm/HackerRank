@echo off
setlocal ENABLEDELAYEDEXPANSION

pushd "%~dp0"
set problem=%~n1

if "%problem%"=="" (
    echo Need to pass problem^^! Available problems are^^:
    REM only .cs files are supported    
    for /F %%I in ('dir /b src\*.cs') do (
        echo %%~nI
    )
    exit /b 1
)

set csc="C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe"

set bin=bin\%problem%
if exist  %bin% rmdir  %bin% /s /q
mkdir  %bin%
if not exist tmp\%problem% mkdir tmp\%problem%
echo Compiling src\%problem%.cs ...
if "%2"=="-pdb" set pdbconfig=/pdb:%bin%\%problem%.pdb /debug
%csc% /out:%bin%\%problem%.exe %pdbconfig% src\%problem%.cs /nologo
if !errorlevel! NEQ 0 exit /b 1

for /F %%i in ('dir /b cases\%problem%\input*.txt') do (
    set inputfile=%%i
    set suffix=!inputfile:~5!
    echo Executing program with test case %%i ...
    %bin%\%problem%.exe < cases\%problem%\%%i > tmp\%problem%\output!suffix!
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
