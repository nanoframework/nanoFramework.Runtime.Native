// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides a set of methods and properties for interacting with the garbage collector.
    /// </summary>
    public static class GC
    {
#pragma warning disable S4200 // Native methods should be wrapped

        /// <summary>
        /// Forces an immediate garbage collection of all generations.
        /// </summary>
        /// <param name="compactHeap">
        /// <see langword="true"/> to force heap compaction; otherwise, <see langword="false"/>.
        /// </param>
        /// <returns>
        /// The amount of free memory, in bytes, after the garbage collection.
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern uint Run(bool compactHeap);

        /// <summary>
        /// Enables or disables the output of garbage collection messages.
        /// </summary>
        /// <param name="enable">
        /// <see langword="true"/> to enable the output of GC messages; otherwise, <see langword="false"/>.
        /// </param>
        /// <remarks>
        /// Enabling GC messages may not always result in output, depending on the target build options.
        /// For example, RTM builds, which remove all non-essential features, may not output these messages.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void EnableGCMessages(bool enable);

#pragma warning restore S4200 // Native methods should be wrapped
    }
}
