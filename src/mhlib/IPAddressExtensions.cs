/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System.Net;
using System.Net.Sockets;

namespace mhed.lib
{
    /// <summary>
    /// Special class with System.Net.IPAddress extensions.
    /// </summary>
    public static class IPAddressExtensions
    {
        /// <summary>
        /// Compare two IP addresses.
        /// </summary>
        /// <param name="LeftValue">First IP address for comparansion.</param>
        /// <param name="RightValue">Second IP address for comparansion.</param>
        /// <returns>New relative order.</returns>
        public static int CompareTo(this IPAddress LeftValue, IPAddress RightValue)
        {
            byte[] left = LeftValue.AddressFamily != AddressFamily.InterNetworkV6 ? LeftValue.MapToIPv6().GetAddressBytes() : LeftValue.GetAddressBytes();
            byte[] right = RightValue.AddressFamily != AddressFamily.InterNetworkV6 ? RightValue.MapToIPv6().GetAddressBytes() : RightValue.GetAddressBytes();
            int order = 0;

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] < right[i])
                {
                    order = -1;
                    break;
                }
                else if (left[i] > right[i])
                {
                    order = 1;
                    break;
                }
            }

            return order;
        }
    }
}
