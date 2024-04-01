..
    SPDX-FileCopyrightText: 2011-2024 EasyCoding Team

    SPDX-License-Identifier: GPL-3.0-or-later

.. _usage:

************************************
Using application
************************************

.. index:: working with hosts editor, editing hosts file
.. _usage-edit:

Editing Hosts file
==========================================

In the first column **IP-address** you must enter a valid IP address (eg. ``127.0.0.1``), in the second **Hostname**, the hostname (eg. ``localhost``), and in the third **Comment** -- optional comment, if necessary. Both IPv4 and IPv6 are supported.

Multiple hostnames are allowed in one entry. Use a space as a separator. Quotation marks or wildcards are strictly prohibited. Inline commentaries are also forbidden. Use a separate column for this.

To add a new row, just start typing text in the last cell.

To edit the contents of a cell, double-click on it or simply start typing a new value.

If you want to edit Hosts file as a plain text file, click **Open in text editor** in the **Advanced** menu. The file will be loaded with a :ref:`selected <settings-advanced>` (or system default) text editor.

.. index:: reloading hosts file, refreshing hosts file
.. _usage-reload:

Reloading Hosts file
==========================================

Click the **Refresh** button on the main toolbar, or press **F5** button on your keyboard to reload the Hosts file from disk.

Any unsaved changes will be lost.

.. index:: saving hosts file
.. _usage-save:

Saving Hosts file
================================================

Click the **Save** button on the main toolbar, or press **Ctrl + S** key combination on your keyboard to save the Hosts file to disk.

.. index:: importing hosts file
.. _usage-import:

Importing Hosts file entries
===================================================

If you want to import entries from external file, you can use the **File** -- **Import** menu item.

Select a text file using the standard OS dialog and click the **Open** button.

Only one file can be imported at once with an unlimited number of entries.

.. index:: exporting hosts file
.. _usage-export:

Exporting Hosts file entries
===================================================

If you want to export entries to external file, you can use the **File** -- **Export** menu item.

Select a text file using the standard OS dialog and click the **Save** button.

.. index:: hosts file encoding
.. _usage-encoding:

Hosts file encoding
=====================================

The application supports the following Hosts encodings:

  * System default;
  * Unicode.

You can select the preferred encoding from the **Advanced** -- **File encoding** menu.

This setting will affect all actions and will persist between program runs.

.. index:: cut to clipboard
.. _usage-clipboard-cut:

Cut to clipboard
===============================

You can select and cut any entries to the clipboard by using the **Edit** -- **Cut** menu item, the **Cut** context menu item or the **Ctrl+X** :ref:`hotkey <usage-hotkeys>`.

The data will be copied as tab-delimited plain text, removed from the table, and can be pasted into any application.

.. index:: copy to clipboard
.. _usage-clipboard-copy:

Copy to clipboard
===============================

You can select and copy any entries to the clipboard by using the **Edit** -- **Copy** menu item, the **Copy** context menu item or the **Ctrl+C** :ref:`hotkey <usage-hotkeys>`.

The data will be copied as a tab-delimited plain text, and can be pasted into any application.

.. index:: paste from clipboard
.. _usage-clipboard-paste:

Paste from clipboard
===============================

You can paste one or more entries from the clipboard by using the **Edit** -- **Paste** menu item, the **Paste** context menu item or the **Ctrl+V** :ref:`hotkey <usage-hotkeys>`.

If only one cell is selected, insertion at the selection point will be used, otherwise the alternative mode of inserting the entire row will be used.

If you want to replace an existing row, you must first select it by clicking on the row selector (first column). Otherwise it will be inserted at the end of the table.

.. index:: removing rows
.. _usage-remove:

Removing rows
===============================

You can select and remove one or more rows by using the **Edit** -- **Delete** menu item, the **Delete** context menu item or the **Shift+Del** :ref:`hotkey <usage-hotkeys>`.

.. index:: status bar
.. _usage-status:

Status bar
=======================

The status bar displays the following:

  * full path to the active Hosts file. Click to show it in the default file manager;
  * current operating mode:

    * **R/O** -- read-only. Click to restart the program with administrator rights.
    * **R/W** -- read and write.

.. index:: hotkeys, keyboard keys
.. _usage-hotkeys:

Hotkeys
===========================================

Hotkeys can be used to control the application.

Currently supported keyboard combinations:

  * **F1** -- show offline help;
  * **F5** -- :ref:`reload <usage-reload>` the Hosts file from disk;
  * **Ctrl+S** -- :ref:`save <usage-save>` the Hosts file to disk;
  * **Ctrl+Q** -- quit application;
  * **Ctrl+X** -- :ref:`cut <usage-clipboard-cut>` the selected cell data to the clipboard;
  * **Ctrl+C** -- :ref:`copy <usage-clipboard-copy>` the selected cell data to the clipboard;
  * **Ctrl+V** -- :ref:`paste <usage-clipboard-paste>` data from the clipboard to the selected cell or row;
  * **Shift+Del** -- :ref:`remove <usage-remove>` the selected rows.
