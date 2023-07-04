/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Net;
using System.Net.Sockets;

namespace mhed.lib
{
    /// <summary>
    /// Class with static methods for working with various IP addresses and
    /// hostnames.
    /// </summary>
    public static class AddressHelpers
    {
        /// <summary>
        /// Get an integer representation of the specified IPv4 address.
        /// </summary>
        /// <param name="SrcIPAddress">Source IPv4 address.</param>
        /// <returns>Integer representation of the specified IPv4 address.</returns>
        public static uint GetIntegerFromIPv4Address(IPAddress SrcIPAddress)
        {
            if (SrcIPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                throw new ArgumentException("IPv6 is not supported because we can't handle 128-bit integers.", nameof(SrcIPAddress));
            }

            byte[] IPAddressBytes = SrcIPAddress.GetAddressBytes();
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(IPAddressBytes);
            }
            return BitConverter.ToUInt32(IPAddressBytes, 0);
        }

        /// <summary>
        /// Get an IPv4 address from the integer representation.
        /// </summary>
        /// <param name="SrcIPAddress">Integer representation of the source IPv4 address.</param>
        /// <returns>IPv4 address.</returns>
        public static IPAddress GetIPv4AddressFromInteger(uint SrcIPAddress)
        {
            byte[] IPAddressBytes = BitConverter.GetBytes(SrcIPAddress);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(IPAddressBytes);
            }
            return new IPAddress(IPAddressBytes);
        }
    }
}
