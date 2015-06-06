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

start https://www.hackerrank.com/challenges/%problem%