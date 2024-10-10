// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace nanoFramework.Runtime.Native
{
    ///////////////////////////////////////////////////////////////////////////////////////
    // !!! KEEP IN SYNC WITH nanoFramework.Tools.Debugger.WireProtocol.RebootOptions !!! //
    ///////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Specifies the reboot options for a .NET nanoFramework device.
    /// </summary>
    public enum RebootOption
    {
        /// <summary>
        /// Perform a normal reboot of the CPU. This is an hard reset.
        /// </summary>
#pragma warning disable S2346 // Need this to be 0 because of native implementation
        NormalReboot = 0,
#pragma warning restore S2346 // Flags enumerations zero-value members should be named "None"

        /// <summary>
        /// Reboot and enter the nanoBooter.
        /// </summary>
        EnterNanoBooter = 1,

        /// <summary>
        /// Reboot the Common Language Runtime (CLR) only.
        /// </summary>
        ClrOnly = 2,

        //////////////////////////////
        // can't use option value 4 //
        //////////////////////////////

        /// <summary>
        /// Reboot and enter the proprietary bootloader.
        /// </summary>
        EnterProprietaryBooter = 8,
    };
}
