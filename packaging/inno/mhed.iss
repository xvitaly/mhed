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

#define VERSION GetFileVersion("..\..\src\bin\Release\mhed.exe")
#define BASEDIR "..\..\src"
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
OutputBaseFilename=mhed_v100
#else
OutputBaseFilename=mhed_{#CI_COMMIT}
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

[CustomMessages]
OptNetStatus=Optimizing MSIL binary...
OptNetUninstallStatus=Removing optimized MSIL binaries...
russian.OptNetStatus=Идёт оптимизация MSIL приложения...
russian.OptNetUninstallStatus=Идёт удаление машинных сборок MSIL...

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; InfoBeforeFile: "readme_iss.rtf"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; InfoBeforeFile: "readme_iss.rtf"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#BASEDIR}\bin\Release\mhed.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BASEDIR}\bin\Release\mhed.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BASEDIR}\bin\Release\mhed.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BASEDIR}\bin\Release\ru\*"; DestDir: "{app}\ru\"; Flags: ignoreversion recursesubdirs createallsubdirs
#ifdef _RELEASE
Source: "{#BASEDIR}\bin\Release\mhed.exe.sig"; DestDir: "{app}"; Flags: ignoreversion
#endif

[Icons]
Name: "{group}\Micro Hosts Editor"; Filename: "{app}\mhed.exe"
Name: "{group}\{cm:ProgramOnTheWeb,Micro Hosts Editor}"; Filename: "https://github.com/xvitaly/mhed"
Name: "{userdesktop}\Micro Hosts Editor"; Filename: "{app}\mhed.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Micro Hosts Editor"; Filename: "{app}\mhed.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\mhed.exe"; Description: "{cm:LaunchProgram,Micro Hosts Editor}"; Flags: nowait postinstall skipifsilent
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\mhed.exe"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdmin()

[UninstallRun]
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\mhed.exe"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdmin()

[Code]
function GetDefRoot(Param: String): String;
begin
  if not IsAdmin then
    Result := ExpandConstant('{localappdata}')
  else
    Result := ExpandConstant('{pf}')
end;
