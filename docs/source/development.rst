..
    SPDX-FileCopyrightText: 2011-2022 EasyCoding Team

    SPDX-License-Identifier: GPL-3.0-or-later

.. _development:

**********************************
Development
**********************************

.. index:: development, building from sources
.. _building-from-sources:

Building from sources
==========================================

There are two supported ways to build application from sources:

  * fully automatic build;
  * manual build.

Preparing to build
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

  1. Clone this repository or download the source tarball from the `releases page <https://github.com/xvitaly/mhed/releases>`_.
  2. Install pre-requirements.

Installing pre-requirements
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

First you will need to install C# complier, Microsoft .NET Framework SDK and other required tools (all steps are mandatory):

  1. download the `Microsoft Visual Studio 2019 Community <https://visualstudio.microsoft.com/vs/community/>`_ installer and run it;
  2. select the **Microsoft Visual Studio 2019 Community**, enable the **Classic .NET application development** component, then switch to the **Additional components** tab and enable the **NuGet package manager**;
  3. install the Microsoft Visual Studio 2019 Community;
  4. download the latest version of `NuGet CLI <https://www.nuget.org/downloads>`_ and copy its executable to any directory, located in the ``%PATH%`` environment variable;
  5. install `Doxygen for Windows <http://www.doxygen.nl/download.html>`_ to default directory;
  6. download and install `HTML Help Workshop <https://www.microsoft.com/en-us/download/details.aspx?id=21138>`_;
  7. download and install `Gpg4Win <https://www.gpg4win.org/>`_ to default directory;
  8. download and install `Python 3 for Windows <https://www.python.org/downloads/windows/>`_;
  9. open terminal and install Sphinx-doc using PIP: ``pip3 install sphinx``;
  10. download and install `7-Zip for Windows <https://www.7-zip.org/download.html>`_ to default directory;
  11. download and install `InnoSetup <http://www.jrsoftware.org/isdl.php>`_ to default directory.

Automatic build
^^^^^^^^^^^^^^^^^^^^^^^^^

If you want to use automatic build, follow these steps:

  1. install pre-requirements;
  2. double click on the ``packaging/build_win.cmd`` script.

You will find results in the ``packaging/results`` directory.

Manual build
^^^^^^^^^^^^^^^^^^^^^^^^^

If you don't want to use automatic method, you can build this project manually.

Building main project
++++++++++++++++++++++++++++++++

  1. Start the Microsoft Visual Studio 2019 Community.
  2. **File** -- **Open** -- **Project or solution**, select ``mhed.sln``, then press **Open** button.
  3. **Tools** -- **NuGet Package Manager** -- **Manage NuGet packages for Solution**, press **Restore** button.
  4. **Build** -- **Configuration manager** -- **Active solution configuration** -- **Release**, then press **Close** button.
  5. **Build** -- **Build solution**.

You will find results in the ``src/mhed/bin/Release`` directory.

Building installer
+++++++++++++++++++++++++++++++

  1. Run InnoSetup Compiler.
  2. Open the ``packaging/inno/mhed.iss`` file.
  3. **Build** -- **Compile**.

If the InnoSetup will complain about missing ``*.sig`` files, you will need to manually sign (use detached signatures) compiled binaries with GnuPG by using Gpg4Win, or remove these rows from the InnoSetup script.

You will find results in the ``packaging/results`` directory.

.. index:: development, update, database, updates database
.. _updates-database:

Updates database documentation
================================================

The original source file is located in ``assets/updates.xml``.

Properties
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Level 0:

  * ``Updates`` -- XML root element.

Level 1:

  * ``Application`` -- sub-element with application update metadata.

Level 2:

  * ``Version`` -- application version;
  * ``Info`` -- changelog or release notes URL;
  * ``URL`` -- direct download URL (no redirects are allowed);
  * ``Hash2`` -- download file SHA2 (SHA-512) hash.
