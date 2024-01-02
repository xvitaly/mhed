/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

namespace mhed.lib
{
    /// <summary>
    /// Class for working with application return codes.
    /// </summary>
    public static class ReturnCodes
    {
        /// <summary>
        /// Successful exit without any errors.
        /// </summary>
        public static int Success => 0;

        /// <summary>
        /// Application is already running.
        /// </summary>
        public static int AppAlreadyRunning => 7;

        /// <summary>
        /// Core library version missmatch.
        /// </summary>
        public static int CoreLibVersionMissmatch => 8;

        /// <summary>
        /// Hosts file does not exists.
        /// </summary>
        public static int HostsFileDoesNotExists => 9;

        /// <summary>
        /// Application update pending.
        /// </summary>
        public static int AppUpdatePending => 10;
    }
}
