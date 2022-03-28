//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

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
