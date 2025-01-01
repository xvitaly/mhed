/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.ComponentModel;
using System.Globalization;

namespace mhed.lib
{
    /// <summary>
    /// Provides a way for converting Hostname to string and vice versa.
    /// </summary>
    public sealed class HostnameConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this class can convert an object from string.
        /// </summary>
        /// <param name="Context">Formatting context.</param>
        /// <param name="SourceType">Source type.</param>
        /// <returns>Whether this class can convert an object.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext Context, Type SourceType)
        {
            if (SourceType == typeof(string)) { return true; }
            return base.CanConvertFrom(Context, SourceType);
        }

        /// <summary>
        /// Returns whether this class can convert an object to string.
        /// </summary>
        /// <param name="Context">Formatting context.</param>
        /// <param name="DestinationType">Destination type.</param>
        /// <returns>Whether this class can convert an object.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext Context, Type DestinationType)
        {
            if (DestinationType == typeof(string)) { return true; }
            return base.CanConvertTo(Context, DestinationType);
        }

        /// <summary>
        /// Converts an object from string.
        /// </summary>
        /// <param name="Context">Formatting context.</param>
        /// <param name="Culture">Current culture.</param>
        /// <param name="Value">Object for conversion.</param>
        /// <returns>Converted object.</returns>
        public override object ConvertFrom(ITypeDescriptorContext Context, CultureInfo Culture, object Value)
        {
            if (Value is string StrValue) { return Hostname.Parse(StrValue); }
            return base.ConvertFrom(Context, Culture, Value);
        }

        /// <summary>
        /// Converts an object to string.
        /// </summary>
        /// <param name="Context">Formatting context.</param>
        /// <param name="Culture">Current culture.</param>
        /// <param name="Value">Object for conversion.</param>
        /// <param name="DestinationType">Destination type.</param>
        /// <returns>Converted object.</returns>
        public override object ConvertTo(ITypeDescriptorContext Context, CultureInfo Culture, object Value, Type DestinationType)
        {
            if (DestinationType == typeof(string)) { DestinationType.ToString(); }
            return base.ConvertTo(Context, Culture, Value, DestinationType);
        }
    }
}
