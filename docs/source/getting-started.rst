..
    SPDX-FileCopyrightText: 2011-2021 EasyCoding Team

    SPDX-License-Identifier: GPL-3.0-or-later

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
