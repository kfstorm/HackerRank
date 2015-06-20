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

start https://www.hackerrank.com/challenges/%problem%