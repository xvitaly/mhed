@echo off

rem This file is a part of Micro Hosts Editor project. For more information
rem visit official site: https://www.easycoding.org/projects/mhed
rem
rem Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
rem Copyright (c) 2005 - 2020 EasyCoding Team.
rem
rem This program is free software: you can redistribute it and/or modify
rem it under the terms of the GNU General Public License as published by
rem the Free Software Foundation, either version 3 of the License, or
rem (at your option) any later version.
rem
rem This program is distributed in the hope that it will be useful,
rem but WITHOUT ANY WARRANTY; without even the implied warranty of
rem MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
rem GNU General Public License for more details.
rem
rem You should have received a copy of the GNU General Public License
rem along with this program. If not, see <http://www.gnu.org/licenses/>.

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
