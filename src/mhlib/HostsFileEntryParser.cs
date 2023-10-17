/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mhed.lib
{
    public sealed class HostsFileEntryParser
    {
        public string IP { get; private set; }
        public string Host { get; private set; }
        public string Comment { get; private set; }

        private static HostsFileEntryParser InternalParse(string Value, bool TryParse)
        {
            // Checking the source string for null...
            if (string.IsNullOrWhiteSpace(Value))
            {
                if (TryParse) { return null; } else { throw new ArgumentException("Hosts file entry string cannot be null, empty or contain only spaces.", nameof(Value)); }
            }

            // Calculating the indices of the first space and the hash character...
            int SpaceIndex = Value.IndexOf(" ", StringComparison.InvariantCulture);
            int CommentIndex = Value.IndexOf("#", StringComparison.InvariantCulture);

            // If the source string contains no spaces, it can't be parsed correctly...
            if (SpaceIndex == -1)
            {
                if (TryParse) { return null; } else { throw new FormatException("Hosts file entry string has incorrect format."); }
            }

            // Parsing the source string...
            try
            {
                return new HostsFileEntryParser(Value.Substring(0, SpaceIndex), CommentIndex > SpaceIndex ? Value.Substring(SpaceIndex + 1, CommentIndex - SpaceIndex - 2) : Value.Remove(0, SpaceIndex + 1), CommentIndex > 0 ? Value.Substring(CommentIndex + 1).Trim() : string.Empty);
            }
            catch (Exception Ex)
            {
                if (TryParse) { return null; } else { throw Ex; }
            }
        }

        public static bool TryParse(string SrcStr, out HostsFileEntryParser Parser)
        {
            Parser = InternalParse(SrcStr, true);
            return !(Parser is null);
        }

        public static HostsFileEntryParser Parse(string SrcStr)
        {
            return InternalParse(SrcStr, false);
        }

        private HostsFileEntryParser(string IPStr, string HostStr, string CommentStr)
        {
            IP = IPStr;
            Host = HostStr;
            Comment = CommentStr;
        }
    }
}
