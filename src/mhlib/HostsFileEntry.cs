/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System.Net;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with fully-qualified Hosts file entries.
    /// </summary>
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
        /// Get or set entry commentary.
        /// </summary>
        public string Commentary { get; set; }

        /// <summary>
        /// Check if the IP address and the Hostname are not empty.
        /// </summary>
        public bool IsValid => !(IPAddr is null) && !(Hostname is null);

        /// <summary>
        /// HostsFileEntry class constructor.
        /// </summary>
        /// <param name="IP">IP address.</param>
        /// <param name="Host">Associated hostname.</param>
        /// <param name="Comment">Entry commentary.</param>
        public HostsFileEntry(IPAddress IP, Hostname Host, string Comment)
        {
            IPAddr = IP;
            Hostname = Host;
            Commentary = Comment;
        }

        /// <summary>
        /// HostsFileEntry class secondary constructor.
        /// </summary>
        /// <param name="IP">IP address in string format.</param>
        /// <param name="Host">Associated hostname.</param>
        /// <param name="Comment">Entry commentary.</param>
        public HostsFileEntry(string IP, string Host, string Comment)
        {
            IPAddr = IPAddress.Parse(IP);
            Hostname = Hostname.Parse(Host);
            Commentary = Comment;
        }

        /// <summary>
        /// HostsFileEntry class alternative constructor for new lines.
        /// </summary>
        public HostsFileEntry()
        {
            IPAddr = IPAddress.Loopback;
            Hostname = Hostname.Empty;
            Commentary = string.Empty;
        }
    }
}
