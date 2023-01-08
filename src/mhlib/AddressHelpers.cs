/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Net;

namespace mhed.lib
{
    /// <summary>
    /// Class with static methods for working with various IP addresses and
    /// hostnames.
    /// </summary>
    public static class AddressHelpers
    {
        /// <summary>
        /// Validate IP-address.
        /// </summary>
        /// <param name="SrcIPAddress">Source IP-address for validation.</param>
        /// <returns>Return True if the source IP-address is correct.</returns>
        public static bool ValidateIPAddress(string SrcIPAddress)
        {
            return IPAddress.TryParse(SrcIPAddress, out _);
        }

        /// <summary>
        /// Validate hostname.
        /// </summary>
        /// <param name="SrcHostname">Source hostname for validation.</param>
        /// <returns>Return True if the source hostname is correct.</returns>
        public static bool ValidateHostname(string SrcHostname)
        {
            return Uri.CheckHostName(SrcHostname) == UriHostNameType.Dns;
        }

        /// <summary>
        /// Get an integer representation of the specified IPv4 address.
        /// </summary>
        /// <param name="SrcIPAddress">Source IPv4 address.</param>
        /// <returns>Integer representation of the specified IPv4 address.</returns>
        public static uint GetIntegerFromIPv4Address(string SrcIPAddress)
        {
            byte[] IPAddressBytes = IPAddress.Parse(SrcIPAddress).GetAddressBytes();
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
        public static string GetIPv4AddressFromInteger(uint SrcIPAddress)
        {
            byte[] IPAddressBytes = BitConverter.GetBytes(SrcIPAddress);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(IPAddressBytes);
            }
            return new IPAddress(IPAddressBytes).ToString();
        }
    }
}
