.. This file is a part of Micro Hosts Editor. For more information
.. visit official site: https://www.easycoding.org/projects/mhed
..
.. Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
.. Copyright (c) 2005 - 2020 EasyCoding Team.
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
.. _usage:

************************************
Using application
************************************

.. index:: hosts editor, working with hosts editor
.. _usage-working:

Working with Editor
==========================================

In the first column **IP-address** you must enter a valid IP address (eg. ``127.0.0.1``), and in the second **Hostname**, the hostname (eg. ``localhost``).

Multiple hostnames are allowed in one entry. Use a space as a separator. Quotation marks or wildcards are strictly prohibited. Commentaries are also forbidden and will be automatically removed.

To add a new row, just start typing text in the last cell.

To edit the contents of a cell, simply double click on it or press the **F4** on your keyboard.

To remove currently selected row, press **Delete selected row** button on the main toolbar, or press **Delete** button on the keyboard. You can select and remove multiple rows at once.

If you want to edit Hosts file as a plain text file, click **Open config in Notepad** in the **Advanced** menu. The file will be loaded with a :ref:`selected <settings-advanced>` (or system default) text editor.

.. index:: hosts editor, reloading hosts file, refreshing hosts file
.. _usage-reloading:

Reloading Hosts file
==========================================

Click the **Refresh** button on the main toolbar, or press **F5** button on your keyboard to reload the Hosts file from disk.

Any unsaved changes will be lost.

.. index:: hosts editor, loading config file
.. _usage-saving:

Saving Hosts file
================================================

Click the **Save** button on the main toolbar, or press **Ctrl + S** key combination on your keyboard to save the Hosts file to disk.
