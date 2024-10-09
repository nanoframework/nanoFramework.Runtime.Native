// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Provides information about, and means to manipulate, the current environment and platform. This class cannot be inherited.
    /// </summary>
    public static partial class Environment
    {
        /// <summary>
        /// Gets the number of milliseconds elapsed since the system started.
        /// </summary>
        /// <value>The elapsed milliseconds since the system started.</value>
        public static extern long TickCount64
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }
    }
}
