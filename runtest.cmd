@echo off
setlocal ENABLEDELAYEDEXPANSION

pushd "%~dp0"
set problem=%~n1

if "%problem%"=="" (
    echo Need to pass problem^^! Available problems are^^:
    for /F %%I in ('dir /b src\*.*') do (
        echo %%~nI
    )
    exit /b 1
)

set bin=bin\%problem%
if exist  %bin% rmdir  %bin% /s /q
mkdir  %bin%
if not exist tmp\%problem% mkdir tmp\%problem%

for /F %%I in ('dir /b src\%problem%.*') do (
    set SourceFileFound=true
    call :Compile %%I %2
    if !errorlevel! NEQ 0 exit /b
)
if [%SourceFileFound%] == [] (
    echo Problem '%problem%' not found^^!
    exit /b 1
)

for /F %%i in ('dir /b cases\%problem%\input*.txt') do (
    set InputFileFound=true
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

if [%InputFileFound%] == [] (
    echo Test case not found^^!
    exit /b 1
)

echo Test passed.

goto :EOF

:OutputMismatch
echo Output mismatch^^!
exit /b 1


:Compile
set _csc="C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe"
set _cl="C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\bin\cl.exe"
echo Compiling src\%1 ...
if "%~x1"==".cs" goto :CS
if "%~x1"==".cpp" goto :CPP
if "%~x1"==".c" goto :CPP
echo Unsupported language^^!
exit /b 1
:CS
if "%2"=="-pdb" set pdbconfig=/pdb:%bin%\%problem%.pdb /debug
%_csc% /out:%bin%\%problem%.exe %pdbconfig% src\%1 /nologo /fullpaths
goto :CompileEnd
:CPP
%_cl% /EHsc /Fe%bin%\%problem%.exe /Fo%bin%\%problem%.obj %~dp0src\%1 /nologo /W4 /O2
goto :CompileEnd
:CompileEnd
exit /b
