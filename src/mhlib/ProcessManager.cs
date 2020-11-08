/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2020 EasyCoding Team.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
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
