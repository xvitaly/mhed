/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;

namespace mhed.lib
{
    /// <summary>
    /// Class for parsing Hosts file entries.
    /// </summary>
    public sealed class HostsFileEntryParser
    {
        /// <summary>
        /// Gets or sets IP address as a string.
        /// </summary>
        public string IP { get; private set; }

        /// <summary>
        /// Gets or sets hostname as a string.
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Gets or sets comment as a string.
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// An internal implementation of the Hosts file entries strings parser.
        /// Creates an object from the string.
        /// </summary>
        /// <param name="Value">Hosts file entry string for parsing.</param>
        /// <param name="TryParse">Disable exceptions. Return null instead.</param>
        /// <returns>Returns the HostsFileEntryParser object, or null if exceptions are disabled.</returns>
        private static HostsFileEntryParser InternalParse(string Value, bool TryParse)
        {
            // Checking the source string for null...
            if (string.IsNullOrWhiteSpace(Value))
            {
                if (TryParse) { return null; } else { throw new ArgumentException(DebugStrings.AppDbgCoreEntryParserEmptyError, nameof(Value)); }
            }

            // Calculating the indices of the first space and the hash character...
            int SpaceIndex = Value.IndexOf(" ", StringComparison.InvariantCulture);
            int CommentIndex = Value.IndexOf("#", StringComparison.InvariantCulture);

            // If the source string contains no spaces, it can't be parsed correctly...
            if (SpaceIndex == -1)
            {
                if (TryParse) { return null; } else { throw new FormatException(DebugStrings.AppDbgCoreEntryParserFormatError); }
            }

            // Parsing the source string...
            try
            {
                return new HostsFileEntryParser(Value.Substring(0, SpaceIndex), CommentIndex > SpaceIndex ? Value.Substring(SpaceIndex + 1, CommentIndex - SpaceIndex - 2) : Value.Remove(0, SpaceIndex + 1), CommentIndex > 0 ? Value.Substring(CommentIndex + 1).Trim() : string.Empty);
            }
            catch
            {
                if (TryParse) { return null; } else { throw; }
            }
        }

        /// <summary>
        /// Parse Hosts file entry string to an object without throwing any exceptions.
        /// </summary>
        /// <param name="SrcStr">Hosts file entry string for parsing.</param>
        /// <param name="Parser">An instance of the HostsFileEntryParser object with result.</param>
        /// <returns>Returns if the HostsFileEntryParser object was successfully created.</returns>
        public static bool TryParse(string SrcStr, out HostsFileEntryParser Parser)
        {
            Parser = InternalParse(SrcStr, true);
            return !(Parser is null);
        }

        /// <summary>
        /// Parse Hosts file entry string to an object.
        /// </summary>
        /// <param name="SrcStr">Hosts file entry string for parsing.</param>
        /// <returns>Returns an instance of the HostsFileEntryParser object.</returns>
        public static HostsFileEntryParser Parse(string SrcStr)
        {
            return InternalParse(SrcStr, false);
        }

        /// <summary>
        /// Main constructor of the HostsFileEntryParser class. Should not be used directly.
        /// Use the Parse() or TryParse() methods to create instances.
        /// </summary>
        /// <param name="IPStr">IP address field as a string.</param>
        /// <param name="HostStr">Hostname field as a string.</param>
        /// <param name="CommentStr">Comment field as a string.</param>
        private HostsFileEntryParser(string IPStr, string HostStr, string CommentStr)
        {
            IP = IPStr;
            Host = HostStr;
            Comment = CommentStr;
        }
    }
}
