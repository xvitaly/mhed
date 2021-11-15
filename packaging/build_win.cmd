@echo off

rem
rem SPDX-FileCopyrightText: 2011-2021 EasyCoding Team
rem
rem SPDX-License-Identifier: GPL-3.0-or-later
rem

title Building Micro Hosts Editor release binaries...

set GPGKEY=A989AAAA
set RELVER=100

echo Removing previous build results...
if exist results rd /S /Q results

echo Installing dependencies using NuGet package manager...
pushd ..
nuget restore
popd

echo Starting build process using MSBUILD...
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe" ..\mhed.sln /m /t:Build /p:Configuration=Release /p:TargetFramework=v4.7.2

echo Generating documentation in HTML format...
mkdir "..\src\mhed\bin\Release\help"
pushd helpers
call "build_chm_win.cmd"
popd

echo Signing binaries...
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\mhed.exe
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\mhlib.dll
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\NLog.dll
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% ..\src\mhed\bin\Release\ru\mhed.resources.dll

echo Compiling Installer...
"%ProgramFiles(x86)%\Inno Setup 6\ISCC.exe" inno\mhed.iss

echo Generating archive for non-Windows platforms...
"%PROGRAMFILES%\7-Zip\7z.exe" a -m0=LZMA2 -mx9 -t7z -x!*.ico -x!NLog.xml "results\mhed_v%RELVER%.7z" ".\..\src\mhed\bin\Release\*"

echo Generating developer documentation in HTML format...
pushd ..
"%PROGRAMFILES%\doxygen\bin\doxygen.exe" Doxyfile
"%ProgramFiles(x86)%\HTML Help Workshop\hhc.exe" "doxyout\html\index.hhp"
"%PROGRAMFILES%\7-Zip\7z.exe" a -m0=LZMA2 -mx9 -t7z "packaging\results\mhed_v%RELVER%_dev.7z" ".\doxyout\html\mhed_dev.chm"
popd

echo Signing built artifacts...
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% results\mhed_v%RELVER%.exe
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% results\mhed_v%RELVER%.7z
"%ProgramFiles(x86)%\GnuPG\bin\gpg.exe" --sign --detach-sign --default-key %GPGKEY% results\mhed_v%RELVER%_dev.7z

echo Removing temporary files and directories...
rd /S /Q "..\docs\build\doctrees"
rd /S /Q "..\docs\build\htmlhelp"
rd /S /Q "..\src\mhed\bin"
rd /S /Q "..\src\mhed\obj"
rd /S /Q "..\src\mhlib\bin"
rd /S /Q "..\src\mhlib\obj"
rd /S /Q "..\doxyout"
