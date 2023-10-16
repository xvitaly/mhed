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

        public HostsFileEntryParser(string IPStr, string HostStr, string CommentStr)
        {
            IP = IPStr;
            Host = HostStr;
            Comment = CommentStr;
        }
    }
}
