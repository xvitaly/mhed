/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.ComponentModel;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with hostnames.
    /// </summary>
    [TypeConverter(typeof(HostnameConverter))]
    public sealed class Hostname
    {
        /// <summary>
        /// Stores current hostname entry.
        /// </summary>
        private readonly string _Host;

        /// <summary>
        /// Returns hostname as string.
        /// </summary>
        public override string ToString()
        {
            return _Host;
        }

        /// <summary>
        /// Implicitly converts cast without new to the correct object.
        /// </summary>
        public static implicit operator Hostname(string Value)
        {
            return Value == null ? null : new Hostname(Value);
        }

        /// <summary>
        /// Implicitly converts Hostname object to string.
        /// </summary>
        public static implicit operator string(Hostname Value)
        {
            return Value._Host;
        }

        /// <summary>
        /// Main constructor of the Hostname class.
        /// </summary>
        /// <param name="Value">Hostname entry in string format.</param>
        public Hostname(string Value)
        {
            if (Value == null) { throw new ArgumentNullException("Value", "Hostname value cannot be null."); }
            if (!string.IsNullOrEmpty(Value) && !AddressHelpers.ValidateHostname(Value)) { throw new FormatException("Hostname has incorrect format."); }
            _Host = Value;
        }
    }
}
