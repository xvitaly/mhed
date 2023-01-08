/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Security.Principal;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with processes.
    /// </summary>
    public static class ProcessManager
    {
        /// <summary>
        /// Check if the current user has local adminstrators access rights
        /// (permissions).
        /// </summary>
        /// <returns>Returns True if the current user has admin rights.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static bool IsCurrentUserAdmin()
        {
            bool Result;
            try
            {
                // Checking access rights of currently logged-in user...
                WindowsPrincipal UP = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                // Checking if current user is in Administrators group...
                Result = UP.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                // Exception detected. User has no admin rights.
                Result = false;
            }
            return Result;
        }
    }
}
