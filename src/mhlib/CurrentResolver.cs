/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Threading.Tasks;

namespace mhed.lib
{
    public abstract class CurrentResolver
    {
        /// <summary>
        /// Create a resolver-dependent instance. Factory method.
        /// </summary>
        public static CurrentResolver Create(DNSType Type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Resolve hostname and return the associated IP-address.
        /// </summary>
        /// <param name="Hostname">Hostname to be resolved.</param>
        /// <returns>Associated IP-address.</returns>
        public abstract Task<string> Resolve(string Hostname);

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
