%global debug_package %{nil}

Name: mhed
Version: 0.8.0
Release: 1%{?dist}
Summary: Micro Hosts Editor

License: GPLv3+
URL: https://github.com/xvitaly/%{name}
Source0: %{url}/archive/v%{version}.tar.gz#/%{name}-%{version}.tar.gz
BuildArch: noarch

BuildRequires: mono-winforms
BuildRequires: mono-devel
BuildRequires: desktop-file-utils

Requires: mono-winforms
Requires: hicolor-icon-theme

%description
Micro Hosts Editor is a small, simple, crossplatform and completely free
and open-source tool. You can edit your Hosts file using simple GUI.

%prep
%autosetup -p1

%build
xbuild /p:Configuration=Release %{name}.sln

%install
install -d %{buildroot}%{_bindir} %{buildroot}%{_prefix}/lib/%{name} %{buildroot}%{_prefix}/lib/%{name}/ru %{buildroot}%{_datadir}/icons/hicolor/scalable/apps
install -m 0755 -p package/%{name}.sh %{buildroot}%{_bindir}/%{name}
install -m 0644 -p package/%{name}.svg %{buildroot}%{_datadir}/icons/hicolor/scalable/apps
install -m 0644 -p src/bin/Release/%{name}.exe src/bin/Release/%{name}.exe.config %{buildroot}%{_prefix}/lib/%{name}
install -m 0644 -p src/bin/Release/ru/%{name}.resources.dll %{buildroot}%{_prefix}/lib/%{name}/ru
desktop-file-install --dir=%{buildroot}%{_datadir}/applications package/%{name}.desktop

%files
%doc README.md
%license COPYING.txt
%{_bindir}/%{name}
%{_prefix}/lib/%{name}
%{_datadir}/applications/%{name}.desktop
%{_datadir}/icons/hicolor/scalable/apps/%{name}.svg

%changelog
* Sat Jun 10 2017 Vitaly Zaitsev <vitaly@easycoding.org> - 0.8.0-1
- Updated to version 0.8.

* Fri Jun 09 2017 Vitaly Zaitsev <vitaly@easycoding.org> - 0.7.0-1
- First SPEC release.
