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

title CHM builder for Micro Hosts Editor

echo Building offline help for default (EN) locale...
call "..\..\docs\make.cmd" htmlhelp
"%ProgramFiles(x86)%\HTML Help Workshop\hhc.exe" "..\..\docs\build\htmlhelp\mhed_en.hhp"
move "..\..\docs\build\htmlhelp\mhed_en.chm" "..\..\src\bin\Release\help\mhed_en.chm"

echo Building offline help for RU locale...
set SPHINXOPTS=-D language=ru
set BUILDLANG=ru
call "..\..\docs\make.cmd" htmlhelp
"%ProgramFiles(x86)%\HTML Help Workshop\hhc.exe" "..\..\docs\build\htmlhelp\mhed_ru.hhp"
move "..\..\docs\build\htmlhelp\mhed_ru.chm" "..\..\src\bin\Release\help\mhed_ru.chm"
