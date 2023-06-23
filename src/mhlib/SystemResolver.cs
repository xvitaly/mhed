/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

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
        /// <param name="Host">Hostname to be resolved.</param>
        /// <returns>Associated IP-address.</returns>
        public override async Task<IPAddress[]> Resolve(Hostname Host)
        {
            return await Dns.GetHostAddressesAsync(Host.ToString());
        }
    }
}
