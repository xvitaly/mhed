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
        public string Hostname { get; set; }

        /// <summary>
        /// Check if the IP address is valid and Hostname is not empty.
        /// </summary>
        public bool IsValid => IPAddr != null && !string.IsNullOrWhiteSpace(Hostname);

        /// <summary>
        /// HostsFileEntry class constructor.
        /// </summary>
        /// <param name="IP">IP address.</param>
        /// <param name="Host">Associated hostname.</param>
        public HostsFileEntry(IPAddress IP, string Host)
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
            Hostname = Host;
        }

        /// <summary>
        /// HostsFileEntry class alternative constructor for new lines.
        /// </summary>
        public HostsFileEntry()
        {
            IPAddr = IPAddress.Loopback;
            Hostname = string.Empty;
        }
    }
}
