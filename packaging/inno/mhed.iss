; This file is a part of Micro Hosts Editor project. For more information
; visit official site: https://www.easycoding.org/projects/mhed
;
; Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
; Copyright (c) 2005 - 2020 EasyCoding Team.
;
; This program is free software: you can redistribute it and/or modify
; it under the terms of the GNU General Public License as published by
; the Free Software Foundation, either version 3 of the License, or
; (at your option) any later version.
;
; This program is distributed in the hope that it will be useful,
; but WITHOUT ANY WARRANTY; without even the implied warranty of
; MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
; GNU General Public License for more details.
;
; You should have received a copy of the GNU General Public License
; along with this program. If not, see <http://www.gnu.org/licenses/>.

#define VERSION GetFileVersion("..\..\src\mhed\bin\Release\mhed.exe")
#define BASEDIR "..\..\src\mhed"
#define CI_COMMIT GetEnv('CI_HASH')
#if CI_COMMIT == ''
#define _RELEASE 1
#endif

[Setup]
AppId={{1A3295AB-919E-4E58-B2A3-1B8B9BF8E29D}
AppName=Micro Hosts Editor
AppVerName=Micro Hosts Editor
AppPublisher=EasyCoding Team
AppPublisherURL=https://www.easycoding.org/
AppVersion={#VERSION}
AppSupportURL=https://github.com/xvitaly/mhed/issues
AppUpdatesURL=https://github.com/xvitaly/mhed/releases
DefaultDirName={code:GetDefRoot}\Micro Hosts Editor
DefaultGroupName=Micro Hosts Editor
AllowNoIcons=yes
LicenseFile=..\..\COPYING
OutputDir=..\results
#ifdef _RELEASE
OutputBaseFilename=mhed_v{#GetEnv('RELVER')}
#else
OutputBaseFilename=snapshot_{#CI_COMMIT}
#endif
SetupIconFile={#BASEDIR}\mhed.ico
UninstallDisplayIcon={app}\mhed.exe
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=commandline
ShowLanguageDialog=auto
ArchitecturesInstallIn64BitMode=x64
MinVersion=6.1.7601
VersionInfoVersion={#VERSION}
VersionInfoDescription=Micro Hosts Editor Setup
VersionInfoCopyright=(c) 2005-2020 EasyCoding Team. All rights reserved.
VersionInfoCompany=EasyCoding Team

[Messages]
BeveledLabel=EasyCoding Team

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl,locale\en\cm.isl"; InfoBeforeFile: "locale\en\readme.rtf"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl,locale\ru\cm.isl"; InfoBeforeFile: "locale\ru\readme.rtf"

[Components]
Name: "core"; Description: "{cm:CompCoreDesc}"; Types: full compact custom; Flags: fixed
Name: "debug"; Description: "{cm:CompDebugDesc}"; Types: full
Name: "locales"; Description: "{cm:CompLocalesMetaDesc}"; Types: full
Name: "locales\en"; Description: "{cm:CompLocaleEnDesc}"; Types: full
Name: "locales\ru"; Description: "{cm:CompLocaleRuDesc}"; Types: full

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#BASEDIR}\bin\Release\mhed.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\mhed.pdb"; DestDir: "{app}"; Flags: ignoreversion; Components: debug
Source: "{#BASEDIR}\bin\Release\mhed.exe.config"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\NLog.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\NLog.config"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\ru\mhed.resources.dll"; DestDir: "{app}\ru"; Flags: ignoreversion; Components: locales\ru
Source: "{#BASEDIR}\bin\Release\help\mhed_en.chm"; DestDir: "{app}\help"; Flags: ignoreversion; Components: locales\en
Source: "{#BASEDIR}\bin\Release\help\mhed_ru.chm"; DestDir: "{app}\help"; Flags: ignoreversion; Components: locales\ru

#ifdef _RELEASE
Source: "{#BASEDIR}\bin\Release\mhed.exe.sig"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\NLog.dll.sig"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\ru\mhed.resources.dll.sig"; DestDir: "{app}\ru"; Flags: ignoreversion; Components: locales\ru
#endif

[Icons]
Name: "{group}\Micro Hosts Editor"; Filename: "{app}\mhed.exe"; Components: core
Name: "{group}\{cm:ProgramOnTheWeb,Micro Hosts Editor}"; Filename: "https://github.com/xvitaly/mhed"; Components: core
Name: "{userdesktop}\Micro Hosts Editor"; Filename: "{app}\mhed.exe"; Tasks: desktopicon; Components: core
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Micro Hosts Editor"; Filename: "{app}\mhed.exe"; Tasks: quicklaunchicon; Components: core

[Run]
Filename: "{app}\mhed.exe"; Description: "{cm:LaunchProgram,Micro Hosts Editor}"; Flags: nowait postinstall skipifsilent; Components: core
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\mhed.exe"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdmin(); Components: core
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\NLog.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdmin(); Components: core

[UninstallRun]
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\mhed.exe"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdmin(); Components: core
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\NLog.dll"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdmin(); Components: core

[Code]
function GetDefRoot(Param: String): String;
begin
  if not IsAdmin then
    Result := ExpandConstant('{localappdata}')
  else
    Result := ExpandConstant('{pf}')
end;
