/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2020 EasyCoding Team.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using NLog;
using System.IO;
using System.Text;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with the logger engine.
    /// </summary>
    public static class InternalLogger
    {
        /// <summary>
        /// Initialize the logger engine.
        /// </summary>
        /// <param name="LogSubdirectoryName">Log subdirectory name.</param>
        /// <param name="RequiredLogLevel">Required log level (as int: 0 - trace, 1 - debug, 2 - info).</param>
        public static void Initialize(string LogSubdirectoryName, int RequiredLogLevel = 1)
        {
            NLog.Config.LoggingConfiguration NLogConfig = new NLog.Config.LoggingConfiguration();
            NLog.Targets.FileTarget NLogFileTarget = new NLog.Targets.FileTarget("logfile")
            {
                FileName = Path.Combine(Path.GetTempPath(), LogSubdirectoryName, Properties.Resources.LogFileName),
                ArchiveFileName = Path.Combine(Path.GetTempPath(), LogSubdirectoryName, Properties.Resources.LogFileTemplate),
                Layout = Properties.Resources.LogLayout,
                ArchiveEvery = NLog.Targets.FileArchivePeriod.Month,
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Rolling,
                MaxArchiveFiles = 3,
                ConcurrentWrites = true,
                KeepFileOpen = false,
                Encoding = Encoding.UTF8,
                WriteBom = false
            };

            NLogConfig.AddRule(LogLevel.FromOrdinal(RequiredLogLevel), LogLevel.Fatal, NLogFileTarget);
            LogManager.Configuration = NLogConfig;
        }
    }
}
