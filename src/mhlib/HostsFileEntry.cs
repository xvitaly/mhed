/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

namespace mhed.lib
{
    public sealed class HostsFileEntry
    {
        /// <summary>
        /// Get or set IP address.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Get or set associated hostname.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Check if the IP address or Hostname fields are empty.
        /// </summary>
        public bool IsEmpty => string.IsNullOrWhiteSpace(IPAddress) || string.IsNullOrWhiteSpace(Hostname);

        /// <summary>
        /// Check if the IP address is valid and Hostname is not empty.
        /// </summary>
        public bool IsValid => AddressHelpers.ValidateIPAddress(IPAddress) && !string.IsNullOrWhiteSpace(Hostname);

        /// <summary>
        /// HostsFileEntry class constructor.
        /// </summary>
        /// <param name="IP">IP address.</param>
        /// <param name="Host">Associated hostname.</param>
        public HostsFileEntry(string IP, string Host)
        {
            IPAddress = IP;
            Hostname = Host;
        }

        /// <summary>
        /// HostsFileEntry class alternative constructor.
        /// </summary>
        public HostsFileEntry()
        {
            IPAddress = string.Empty;
            Hostname = string.Empty;
        }
    }
}
