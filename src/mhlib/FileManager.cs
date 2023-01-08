/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.IO;
using System.Security.Cryptography;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with files and directories.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Extract string from the array of bytes.
        /// </summary>
        /// <param name="Source">Source array.</param>
        /// <returns>Result string.</returns>
        private static string ConvertBytesToString(byte[] Source)
        {
            return BitConverter.ToString(Source).Replace("-", string.Empty).ToLowerInvariant();
        }

        /// <summary>
        /// Calculate SHA-512 hash of the specified file.
        /// </summary>
        /// <param name="FileName">Full path to the source file.</param>
        /// <returns>Returns SHA-512 hash of the specified file.</returns>
        public static string CalculateFileSHA512(string FileName)
        {
            using (SHA512 SHA512Crypt = SHA512.Create())
            {
                using (FileStream SourceStream = File.OpenRead(FileName))
                {
                    return ConvertBytesToString(SHA512Crypt.ComputeHash(SourceStream));
                }
            }
        }

        /// <summary>
        /// Check if the specified directory is writable.
        /// </summary>
        /// <param name="DirName">Full directory path.</param>
        /// <returns>Return True if directory writable.</returns>
        public static bool IsDirectoryWritable(string DirName)
        {
            try { using (File.Create(Path.Combine(DirName, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose)) { /* Nothing here. */ } } catch { return false; }
            return true;
        }
    }
}
