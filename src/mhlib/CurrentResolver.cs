/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System.Net;
using System.Threading.Tasks;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with resolver-dependent functions.
    /// </summary>
    public abstract class CurrentResolver
    {
        /// <summary>
        /// Create a resolver-dependent instance. Factory method.
        /// </summary>
        public static CurrentResolver Create()
        {
            return new SystemResolver();
        }

        /// <summary>
        /// Resolve the specified hostname and return the associated IP-address.
        /// </summary>
        /// <param name="Host">Hostname to be resolved.</param>
        /// <returns>Associated IP-address.</returns>
        public abstract Task<IPAddress[]> Resolve(Hostname Host);
    }
}
