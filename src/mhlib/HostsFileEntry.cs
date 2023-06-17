/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System.Net;

namespace mhed.lib
{
    public sealed class HostsFileEntry
    {
        /// <summary>
        /// Get or set IP address.
        /// </summary>
        public IPAddress IPAddr { get; set; }

        /// <summary>
        /// Get or set associated hostname.
        /// </summary>
        public Hostname Hostname { get; set; }

        /// <summary>
        /// Check if the IP address and the Hostname are not empty.
        /// </summary>
        public bool IsValid => !(IPAddr is null) && !(Hostname is null);

        /// <summary>
        /// HostsFileEntry class constructor.
        /// </summary>
        /// <param name="IP">IP address.</param>
        /// <param name="Host">Associated hostname.</param>
        public HostsFileEntry(IPAddress IP, Hostname Host)
        {
            IPAddr = IP;
            Hostname = Host;
        }

        /// <summary>
        /// HostsFileEntry class secondary constructor.
        /// </summary>
        /// <param name="IP">IP address in string format.</param>
        /// <param name="Host">Associated hostname.</param>
        public HostsFileEntry(string IP, string Host)
        {
            IPAddr = IPAddress.Parse(IP);
            Hostname = Hostname.Parse(Host);
        }

        /// <summary>
        /// HostsFileEntry class alternative constructor for new lines.
        /// </summary>
        public HostsFileEntry()
        {
            IPAddr = IPAddress.Loopback;
            Hostname = Hostname.Parse(string.Empty);
        }
    }
}
