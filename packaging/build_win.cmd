@echo off

rem
rem SPDX-FileCopyrightText: 2011-2022 EasyCoding Team
rem
rem SPDX-License-Identifier: GPL-3.0-or-later
rem

title Building Micro Hosts Editor release binaries...

set GPGKEY=A989AAAA
set RELVER=110

if [%CI_HASH%] == [] (
    set PREFIX=mhed_%RELVER%
) else (
    set PREFIX=snapshot_%CI_HASH%
)

echo Removing previous build results...
if exist results rd /S /Q results

echo Installing dependencies using NuGet package manager...
pushd ..
nuget restore
popd

echo Starting build process using MSBUILD...
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe" ..\mhed.sln /m:1 /t:Build /p:Configuration=Release /p:TargetFramework=v4.8

echo Generating documentation in HTML format...
mkdir "..\src\mhed\bin\Release\help"
pushd helpers
call "build_chm_win.cmd"
popd

echo Signing binaries...
if [%CI_HASH%] == [] (
    "%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\mhed.exe
    "%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\mhlib.dll
    "%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\NLog.dll
    "%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\ru\mhed.resources.dll
)

echo Compiling Installer...
"%ProgramFiles(x86)%\Inno Setup 6\ISCC.exe" inno\mhed.iss

echo Generating archive for non-Windows platforms...
"%PROGRAMFILES%\7-Zip\7z.exe" a -tzip -mx9 -mm=Deflate -x!*.ico -x!NLog.xml "results\%PREFIX%_other.zip" ".\..\src\mhed\bin\Release\*"

echo Signing built artifacts...
if [%CI_HASH%] == [] (
    "%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% results\%PREFIX%_setup.exe
    "%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% results\%PREFIX%_other.zip
)

echo Removing temporary files and directories...
rd /S /Q "..\docs\build\doctrees"
rd /S /Q "..\docs\build\htmlhelp"
rd /S /Q "..\src\mhed\bin"
rd /S /Q "..\src\mhed\obj"
rd /S /Q "..\src\mhlib\bin"
rd /S /Q "..\src\mhlib\obj"
