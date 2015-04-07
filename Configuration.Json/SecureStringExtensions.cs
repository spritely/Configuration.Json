// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs">
//   Copyright (c) 2015. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Configuration.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    ///     Contains methods for converting to/from a secure string.
    /// </summary>
    internal static class SecureStringExtensions
    {
        public static Func<T, object> AsFunc<T>(this Action<T> a)
        {
            return item =>
            {
                a(item);
                return null;
            };
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> a)
        {
            enumerable.Select(a.AsFunc()).ToList();
        }

        public static SecureString ToSecureString(this string source)
        {
            var result = new SecureString();

            source.ToCharArray().ForEach(c => result.AppendChar(c));
            result.MakeReadOnly();

            return result;
        }

        public static string ToInsecureString(this SecureString source)
        {
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(source);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
