;
; SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
;
; SPDX-License-Identifier: GPL-3.0-or-later
;

#define VERSION      GetVersionNumbersString("..\..\src\mhed\bin\Release\mhed.exe")
#define BASEDIR      "..\..\src\mhed"
#define CURRENTYEAR  GetDateTimeString('yyyy','','')

#if GetEnv('CI_HASH') == ''
#define _RELEASE 1
#endif

[Setup]
AppId={{1A3295AB-919E-4E58-B2A3-1B8B9BF8E29D}
AppName=Micro Hosts Editor
AppVersion={#VERSION}
AppVerName=Micro Hosts Editor {#VERSION}
AppPublisher=EasyCoding Team
AppPublisherURL=https://www.easycoding.org/
AppSupportURL=https://github.com/xvitaly/mhed/issues
AppUpdatesURL=https://github.com/xvitaly/mhed/releases
ShowLanguageDialog=yes
UsePreviousLanguage=no
LanguageDetectionMethod=uilanguage
DefaultDirName={code:GetDefRoot}\Micro Hosts Editor
DefaultGroupName=Micro Hosts Editor
AllowNoIcons=yes
LicenseFile=..\..\COPYING
OutputDir=..\results
OutputBaseFilename={#GetEnv('PREFIX')}_setup
SetupIconFile={#BASEDIR}\mhed.ico
UninstallDisplayIcon={app}\mhed.exe
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=commandline
ShowLanguageDialog=auto
ArchitecturesInstallIn64BitMode=x64
MinVersion=6.1sp1
VersionInfoVersion={#VERSION}
VersionInfoDescription=Micro Hosts Editor Installer
VersionInfoCopyright=(c) 2011-{#CURRENTYEAR} EasyCoding Team. All rights reserved.
VersionInfoCompany=EasyCoding Team

[Messages]
BeveledLabel=EasyCoding Team

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl,locale\en\cm.isl"; InfoBeforeFile: "locale\en\readme.rtf"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl,locale\ru\cm.isl"; InfoBeforeFile: "locale\ru\readme.rtf"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl,locale\it\cm.isl"; InfoBeforeFile: "locale\it\readme.rtf"

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
Source: "{#BASEDIR}\bin\Release\mhlib.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\mhlib.pdb"; DestDir: "{app}"; Flags: ignoreversion; Components: debug
Source: "{#BASEDIR}\bin\Release\NLog.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\NLog.config"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\ru\mhed.resources.dll"; DestDir: "{app}\ru"; Flags: ignoreversion; Components: locales\ru
Source: "{#BASEDIR}\bin\Release\help\mhed_en.chm"; DestDir: "{app}\help"; Flags: ignoreversion; Components: locales\en
Source: "{#BASEDIR}\bin\Release\help\mhed_ru.chm"; DestDir: "{app}\help"; Flags: ignoreversion; Components: locales\ru

#ifdef _RELEASE
Source: "{#BASEDIR}\bin\Release\mhed.exe.sig"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "{#BASEDIR}\bin\Release\mhlib.dll.sig"; DestDir: "{app}"; Flags: ignoreversion; Components: core
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
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\mhlib.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdmin(); Components: core
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\NLog.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdmin(); Components: core

[UninstallRun]
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\mhed.exe"""; RunOnceId: "NgenMainApp"; Flags: runhidden; Check: IsAdmin(); Components: core
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\mhlib.dll"""; RunOnceId: "NgenCoreLib"; Flags: runhidden; Check: IsAdmin(); Components: core
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\NLog.dll"""; RunOnceId: "NgenNLog"; Flags: runhidden; Check: IsAdmin(); Components: core

[Code]
function GetDefRoot(Param: String): String;
begin
  if not IsAdmin then
    Result := ExpandConstant('{localappdata}')
  else
    Result := ExpandConstant('{pf}')
end;
