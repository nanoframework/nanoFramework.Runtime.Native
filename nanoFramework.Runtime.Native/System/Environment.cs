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
        /// Gets the number of milliseconds that have elapsed since the system started.
        /// </summary>
        /// <value>
        /// A 64-bit signed integer representing the number of milliseconds that have elapsed since the system started.
        /// </value>
        /// <remarks>
        /// This property is intended to be used for measuring time intervals. The value of this property is derived from the system timer and is subject to the resolution of the system timer.
        /// </remarks>
        public static extern long TickCount64
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }
    }
}
