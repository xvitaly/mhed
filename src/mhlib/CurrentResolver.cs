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
    /// Class for working with resolver-dependent functions.
    /// </summary>
    public abstract class CurrentResolver
    {
        /// <summary>
        /// Create a resolver-dependent instance. Factory method.
        /// </summary>
        public static CurrentResolver Create(DNSType Type)
        {
            switch (Type)
            {
                case DNSType.System:
                    return new SystemResolver();
                case DNSType.DoH:
                    return new DoHResolver();
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        /// <summary>
        /// Resolve the specified hostname and return the associated IP-address.
        /// </summary>
        /// <param name="Hostname">Hostname to be resolved.</param>
        /// <returns>Associated IP-address.</returns>
        public abstract Task<IPAddress[]> Resolve(string Hostname);

        /// <summary>
        /// Codes and IDs of available DNS resolvers.
        /// </summary>
        public enum DNSType
        {
            System = 0,
            DoH = 1
        }
    }
}
