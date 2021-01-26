.. This file is a part of Micro Hosts Editor. For more information
.. visit official site: https://www.easycoding.org/projects/mhed
..
.. Copyright (c) 2011 - 2021 EasyCoding Team (ECTeam).
.. Copyright (c) 2005 - 2021 EasyCoding Team.
..
.. This program is free software: you can redistribute it and/or modify
.. it under the terms of the GNU General Public License as published by
.. the Free Software Foundation, either version 3 of the License, or
.. (at your option) any later version.
..
.. This program is distributed in the hope that it will be useful,
.. but WITHOUT ANY WARRANTY; without even the implied warranty of
.. MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
.. GNU General Public License for more details.
..
.. You should have received a copy of the GNU General Public License
.. along with this program. If not, see <http://www.gnu.org/licenses/>.
.. _getting_started:

*******************************
Getting started
*******************************

.. index:: getting started, starting program, launching application
.. _gs-launch:

Starting program
==========================================

You can launch Micro Hosts Editor from the Start menu directly after the installation: **Start** -- **Programs** -- **Micro Hosts Editor** -- **Micro Hosts Editor**.

Micro Hosts Editor will automatically detect and use system default language.

.. index:: administrator rights, permissions, restricted modules, UAC
.. _gs-admin:

Admin permissions
==========================================

Micro Hosts Editor can be started with or without administrator user rights.

When started as a regular user, it will work in read-only mode because only members of the Administrators user group can edit the Hosts file.

If you want to edit the Hosts file, you will need to run this program with administrator user rights. Right-click on the Micro Hosts Editor shortcut in the Start menu or on the desktop, select **Run with administrator** and confirm this action in the Windows UAC dialog box.

.. index:: startup actions
.. _gs-startup:

Startup actions
==========================================

The following actions will be performed on Micro Hosts Editor's startup:

  1. getting Hosts file path;
  2. checking if the Hosts file exists;
  3. performing internal startup actions;
  4. creating user-friendly GUI.

If the program cannot find path to the Hosts file in the Windows Registry (only on Microsoft Windows platform), it will use the default well-known location.

.. index:: data files storage
.. _gs-datafiles:

Data files storage
==========================================

All program settings are stored in the ``%LOCALAPPDATA%\EasyCoding_Team`` directory (each subdirectory for every version).

Logs -- ``%TEMP%\mhed``.

.. index:: removing program, uninstalling program
.. _gs-uninstall:

Uninstalling program
==========================================

If you want to uninstall Micro Hosts Editor from your compuler, use **Control panel** -- **Programs and components** -- **Micro Hosts Editor** -- **Uninstall**.

Uninstaller will automatically remove all program files, shortcuts, registry entries, but will save created by user :ref:`data files <gs-datafiles>`. You can remove them manually.
