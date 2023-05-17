/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Threading.Tasks;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with DNS-over-HTTPS resolver.
    /// </summary>
    public class DoHResolver : CurrentResolver
    {
        /// <summary>
        /// Resolve the specified hostname using DNS-over-HTTPS resolver
        /// and return the associated IP-address.
        /// </summary>
        /// <param name="Hostname">Hostname to be resolved.</param>
        /// <returns>Associated IP-address.</returns>
        public override Task<string> Resolve(string Hostname)
        {
            throw new NotImplementedException();
        }
    }
}
