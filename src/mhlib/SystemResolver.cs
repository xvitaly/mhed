/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Net;
using System.Threading.Tasks;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with system DNS resolver.
    /// </summary>
    public class SystemResolver : CurrentResolver
    {
        /// <summary>
        /// Resolve the specified hostname using system resolver
        /// and return the associated IP-address.
        /// </summary>
        /// <param name="Hostname">Hostname to be resolved.</param>
        /// <returns>Associated IP-address.</returns>
        public override Task<IPAddress[]> Resolve(string Hostname)
        {
            throw new NotImplementedException();
        }
    }
}
