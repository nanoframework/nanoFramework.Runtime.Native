//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides a set of methods and properties that help developers to debug code.
    /// </summary>
    public static class Debug
    {
        /// <summary>
        /// Runs GC (garbage collection), a service that automatically reclaims unused computer memory.
        /// </summary>
        /// <param name="compactHeap"><see langword="true"/> to force heap compaction; otherwise, <see langword="false"/>.</param>
        /// <returns>The amount of free (unused) memory, in bytes.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        extern static public uint GC(bool compactHeap);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Specifies whether GC (garbage collection) messages are enabled.
        /// </summary>
        /// <param name="enable">true to enable output of messages; otherwise, false.</param>
        /// <remarks>
        /// Despite this method enabling the GC messages there is the possibility of those never being outputted depending on the target build options.
        /// RTM builds (which remove all non essential features) are one of those situations.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        extern static public void EnableGCMessages(bool enable);
#pragma warning restore S4200 // Native methods should be wrapped
    }
}
