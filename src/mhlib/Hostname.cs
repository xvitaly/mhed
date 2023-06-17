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
    public sealed class Hostname : IComparable, IEquatable<Hostname>
    {
        /// <summary>
        /// Stores current hostname entry.
        /// </summary>
        private readonly string _Host;

        /// <summary>
        /// Implicitly converts cast without new to the correct object.
        /// </summary>
        public static implicit operator Hostname(string Value)
        {
            return Value == null ? null : Parse(Value);
        }

        /// <summary>
        /// Implicitly converts Hostname object to string.
        /// </summary>
        public static implicit operator string(Hostname Value)
        {
            return Value._Host;
        }

        /// <summary>
        /// Validate hostname.
        /// </summary>
        /// <param name="SrcHostname">Source hostname for validation.</param>
        /// <returns>Return True if the source hostname is correct.</returns>
        private static bool Validate(string SrcHostname)
        {
            bool Result = true;
            if (SrcHostname.IndexOf(' ') == -1)
            {
                Result = Uri.CheckHostName(SrcHostname) == UriHostNameType.Dns;
            }
            else
            {
                foreach (string SingleHost in SrcHostname.Split(' '))
                {
                    if (string.IsNullOrEmpty(SingleHost)) { continue; }
                    Result &= Uri.CheckHostName(SingleHost) == UriHostNameType.Dns;
                }
            }
            return Result;
        }

        /// <summary>
        /// An internal implementation of the Hostname parser. Creates an object
        /// from the string.
        /// </summary>
        /// <param name="Value">Hostname entry in string format.</param>
        /// <param name="TryParse">Disable exceptions. Return null instead.</param>
        /// <returns>Returns the Hostname object, or null if exceptions are disabled.</returns>
        private static Hostname InternalParse(string Value, bool TryParse)
        {
            if (Value == null)
            {
                if (TryParse)
                {
                    return null;
                }
                else
                {
                    throw new ArgumentNullException("Value", "Hostname value cannot be null.");
                }
            }

            if (!string.IsNullOrEmpty(Value) && !Validate(Value))
            {
                if (TryParse)
                {
                    return null;
                }
                else
                {
                    throw new FormatException("Hostname has incorrect format.");
                }
            }

            return new Hostname(Value);
        }

        /// <summary>
        /// Converts a hostname from the string implementation to an object without
        /// throwing any exceptions.
        /// </summary>
        /// <param name="HostStr">Hostname entry in string format.</param>
        /// <param name="Host">An instance of the Hostname object with result.</param>
        /// <returns>Returns the Hostname object was successfully created.</returns>
        public static bool TryParse(string HostStr, out Hostname Host)
        {
            Host = InternalParse(HostStr, true);
            return Host != null;
        }

        /// <summary>
        /// Converts a hostname from the string implementation to an object.
        /// </summary>
        /// <param name="HostStr">Hostname entry in string format.</param>
        /// <returns>Returns an instance of the Hostname object.</returns>
        public static Hostname Parse(string HostStr)
        {
            return InternalParse(HostStr, false);
        }

        /// <summary>
        /// Equality operator handler.
        /// </summary>
        /// <param name="LeftValue">First hostname for comparansion.</param>
        /// <param name="RightValue">Second hostname for comparansion.</param>
        /// <returns>Returns True if both hostnames are equal.</returns>
        public static bool operator ==(Hostname LeftValue, Hostname RightValue)
        {
            if (LeftValue is null) { return RightValue is null; }
            return LeftValue.Equals(RightValue);
        }

        /// <summary>
        /// Greater than operator handler.
        /// </summary>
        /// <param name="LeftValue">First hostname for comparansion.</param>
        /// <param name="RightValue">Second hostname for comparansion.</param>
        /// <returns>Returns True if the left hostname is greater than right.</returns>
        public static bool operator >(Hostname LeftValue, Hostname RightValue)
        {
            return LeftValue.CompareTo(RightValue) > 0;
        }

        /// <summary>
        /// Less than operator handler.
        /// </summary>
        /// <param name="LeftValue">First hostname for comparansion.</param>
        /// <param name="RightValue">Second hostname for comparansion.</param>
        /// <returns>Returns True if the left hostname is less than right.</returns>
        public static bool operator <(Hostname LeftValue, Hostname RightValue)
        {
            return LeftValue.CompareTo(RightValue) < 0;
        }

        /// <summary>
        /// Inequality operator handler.
        /// </summary>
        /// <param name="LeftValue">First hostname for comparansion.</param>
        /// <param name="RightValue">Second hostname for comparansion.</param>
        /// <returns>Returns True if both hostnames are not equal.</returns>
        public static bool operator !=(Hostname LeftValue, Hostname RightValue)
        {
            return !(LeftValue == RightValue);
        }

        /// <summary>
        /// Returns hostname as string.
        /// </summary>
        public override string ToString()
        {
            return _Host;
        }

        /// <summary>
        /// Tests if two instances of Hostname are equal.
        /// </summary>
        /// <param name="obj">Second hostname for comparansion.</param>
        /// <returns>New relative order.</returns>
        public override bool Equals(object obj)
        {
            return _Host.Equals(obj.ToString());
        }

        /// <summary>
        /// Gets hash code of the object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return _Host.GetHashCode();
        }

        /// <summary>
        /// Compares two Hostname instances as strings.
        /// </summary>
        /// <param name="obj">Second hostname for comparansion.</param>
        /// <returns>New relative order.</returns>
        public int CompareTo(object obj)
        {
            return string.Compare(_Host, obj.ToString(), StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Tests if two instances of Hostname are equal.
        /// </summary>
        /// <param name="other">Second hostname for comparansion.</param>
        /// <returns>New relative order.</returns>
        public bool Equals(Hostname other)
        {
            return _Host.Equals(other);
        }

        /// <summary>
        /// Main constructor of the Hostname class. Should not be used directly.
        /// Use the Parse() or TryParse() methods to create instances.
        /// </summary>
        /// <param name="Value">Hostname entry in string format.</param>
        private Hostname(string Value)
        {
            _Host = Value;
        }
    }
}
