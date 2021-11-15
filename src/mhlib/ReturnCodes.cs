/**
 * SPDX-FileCopyrightText: 2011-2021 EasyCoding Team
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
        public const int Success = 0;

        /// <summary>
        /// Application is already running.
        /// </summary>
        public const int AppAlreadyRunning = 7;

        /// <summary>
        /// Core library version missmatch.
        /// </summary>
        public const int CoreLibVersionMissmatch = 8;

        /// <summary>
        /// Hosts file does not exists.
        /// </summary>
        public const int HostsFileDoesNotExists = 9;
    }
}
