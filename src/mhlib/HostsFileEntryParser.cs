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
        public string IPAddrStr { get; private set; }
        public string HostnameStr { get; private set; }
        public string CommentaryStr { get; private set; }

        public HostsFileEntryParser(string SrcStr)
        {
        }
    }
}
