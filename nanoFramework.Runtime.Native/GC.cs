// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides a set of methods and properties to control GC (garbage collection), a service that automatically reclaims unused computer memory.
    /// </summary>
    public static class GC
    {
#pragma warning disable S4200 // Native methods should be wrapped

        /// <summary>
        /// Runs GC (garbage collection), a service that automatically reclaims unused computer memory.
        /// </summary>
        /// <param name="compactHeap"><see langword="true"/> to force heap compaction; otherwise, <see langword="false"/>.</param>
        /// <returns>The amount of free (unused) memory, in bytes.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern uint Run(bool compactHeap);

        /// <summary>
        /// Specifies whether GC (garbage collection) messages are enabled.
        /// </summary>
        /// <param name="enable">true to enable output of messages; otherwise, false.</param>
        /// <remarks>
        /// Despite this method enabling the GC messages there is the possibility of those never being outputted depending on the target build options.
        /// RTM builds (which remove all non essential features) are one of those situations.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void EnableGCMessages(bool enable);

#pragma warning restore S4200 // Native methods should be wrapped
    }
}
