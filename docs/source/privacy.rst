..
    SPDX-FileCopyrightText: 2011-2024 EasyCoding Team

    SPDX-License-Identifier: GPL-3.0-or-later

.. _privacy:

****************************
Privacy policy
****************************

.. index:: privacy, privacy policy version
.. _privacy-version:

Version
====================

Last update: **2024-01-31**.

.. index:: privacy, application privacy policy
.. _privacy-application:

Application
=================

The application itself doesn't use any telemetry or data collection features.

.. index:: privacy, updater privacy policy
.. _privacy-updater:

Update checker
===================

The update checker module sends the following data to the update web server to obtain information about the availability of new versions, as well as links to download them:

  * IP-address;
  * HTTP_USER_AGENT in a special format, including:

    * OS name;
    * OS version;
    * OS architecture;
    * application name;
    * application version;
    * application language.

This information may be stored in the web server's access.log file for up to 4 weeks before it is permanently deleted. Apart from the above, we don't collect or share any data with anyone.

If you don't want to share it, you can turn off automatic checking for updates in :ref:`Advanced settings <settings-advanced>` and not use this feature.
