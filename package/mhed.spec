%global debug_package %{nil}

Name: mhed
Version: 0.7
Release: 1%{?dist}
Summary: Micro Hosts Editor

License: GPLv3+
URL: https://github.com/xvitaly/%{name}
Source0: %{url}/archive/RELEASE-%{version}.tar.gz#/%{name}-%{version}.tar.gz
Source1: %{name}.desktop
Source2: %{name}.sh
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
%autosetup -n %{name}-RELEASE-%{version} -p1

%build
xbuild /p:Configuration=Release %{name}.sln

%install
install -d %{buildroot}/%{_prefix}/lib/%{name} %{buildroot}/%{_prefix}/lib/%{name}/ru
install -m 0644 -p bin/Release/%{name}.exe bin/Release/%{name}.exe.config %{buildroot}/%{_prefix}/lib/%{name}
install -m 0644 -p bin/Release/ru/%{name}.resources.dll %{buildroot}/%{_prefix}/lib/%{name}/ru

%files
%doc README.md
%license COPYING.txt
%{_prefix}/lib/%{name}

%changelog
* Fri Jun 09 2017 Vitaly Zaitsev <vitaly@easycoding.org> - 0.7-1
- First SPEC release.
