..
    SPDX-FileCopyrightText: 2011-2024 EasyCoding Team

    SPDX-License-Identifier: GPL-3.0-or-later

.. _getting_started:

*******************************
Getting started
*******************************

.. index:: getting started, starting program, launching application
.. _gs-launch:

Starting program
==========================================

You can launch Micro Hosts Editor from the Start menu right after installation: **Start** -- **Micro Hosts Editor** -- **Micro Hosts Editor**.

.. index:: localization selection, language detection, program language
.. _gs-localization:

Localization selection
======================================

Micro Hosts Editor will automatically detect and use the default OS language if supported by the application.

.. index:: administrator rights, permissions, restricted modules, UAC
.. _gs-admin:

Admin permissions
==========================================

Micro Hosts Editor can be started with or without administrator rights.

When started as a regular user, it will work in read-only mode because only members of the Administrators group can edit Hosts file.

If you want to edit Hosts file, you will need to run this program as an administrator. Right-click on the Micro Hosts Editor shortcut in the Start menu or on desktop, select **Run with administrator** and confirm this action in the Windows UAC dialog box.

To always run this application with administrator rights, right-click the shortcut, select the **Properties** context menu item, go to the **Compatibility** tab, check the **Run this program as an administrator** checkbox and click **OK** button.

The program can automatically handle this situation and restart with the correct permissions if you click the green circle in the status bar.

.. index:: startup actions
.. _gs-startup:

Startup actions
==========================================

The following actions will be performed on Micro Hosts Editor's startup:

  1. getting Hosts file path;
  2. checking if the Hosts file exists;
  3. performing internal startup actions;
  4. creating user-friendly GUI;
  5. working with updates, if enabled in :ref:`Advanced settings <settings-advanced>`.

If the program cannot find path to Hosts file in the Windows Registry (only on Microsoft Windows platform), it will use the default well-known location.

.. index:: data files storage
.. _gs-datafiles:

Data files storage
==========================================

All program settings are stored in the ``%LOCALAPPDATA%\EasyCoding_Team`` directory (each subdirectory for every version).

Logs -- ``%LOCALAPPDATA%\mhed\logs``.

.. index:: removing program, uninstalling program
.. _gs-uninstall:

Uninstalling program
==========================================

If you want to uninstall Micro Hosts Editor from your compuler, use **Start** -- **Settings** -- **Apps** -- **Apps & features** -- **Micro Hosts Editor** -- **Uninstall**.

Uninstaller will automatically remove all program files, shortcuts, registry entries, but will save created by user :ref:`data files <gs-datafiles>`. You can remove them manually.

.. index:: mono issues, mono workaround
.. _gs-mono-issues:

Mono issues
==========================================

When running under Mono, the program may crash on start with the following error:

.. code-block:: text

    [ERROR] FATAL UNHANDLED EXCEPTION: System.Configuration.ConfigurationErrorsException:
    Unrecognized configuration section <System.Windows.Forms.ApplicationConfigurationSection>

This is a known `upstream issue <https://github.com/mono/mono/issues/21630>`__.

It can be trivially workarounded by editing the ``mhed.exe.config`` file and removing the following lines:

.. code-block:: xml

    <System.Windows.Forms.ApplicationConfigurationSection>
        <add key="DpiAwareness" value="PerMonitorV2"/>
    </System.Windows.Forms.ApplicationConfigurationSection>

The next launch will be successful.
