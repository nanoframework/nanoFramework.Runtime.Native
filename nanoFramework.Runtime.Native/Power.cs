// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Represents the method that will handle the <see cref="Power.OnRebootEvent"/> event.
    /// </summary>
    public delegate void RebootEventHandler();

    /// <summary>
    /// Provides access to power management functionalities on the target device.
    /// </summary>
    /// <remarks>
    /// This API is a general one common to all devices. There are platform-specific APIs available.
    /// </remarks>
    public class Power
    {
        /// <summary>
        /// Occurs before the device reboots.
        /// </summary>
        /// <remarks>
        /// The event handlers may have an execution constraint placed on them by the caller of the <see cref="RebootDevice()"/> method.
        /// Therefore, it is recommended that the event handlers perform short, atomic operations.
        /// </remarks>
        public static event RebootEventHandler OnRebootEvent;

        /// <summary>
        /// Forces a reboot of the device.
        /// </summary>
        /// <remarks>
        /// This method raises the <see cref="OnRebootEvent"/>. If there are any handlers subscribing to <see cref="OnRebootEvent"/>, the reboot will occur only after all handlers complete their execution, regardless of the time taken.
        /// To set a timeout for the handlers to complete, use the <see cref="RebootDevice(int)"/> method and specify an execution constraint.
        /// </remarks>
        public static void RebootDevice()
        {
            RebootDevice(-1);
        }

        /// <summary>
        /// Forces a reboot of the device with an execution constraint timeout for event handlers.
        /// </summary>
        /// <param name="exeConstraintTimeout">
        /// The execution constraint timeout, in milliseconds, for the event handlers to complete. 
        /// If the event handlers take longer than the allotted time, they will be aborted and the reboot will be executed.
        /// </param>
        public static void RebootDevice(int exeConstraintTimeout)
        {
            try
            {
                ExecutionConstraint.Install(exeConstraintTimeout, 4);
                OnRebootEvent?.Invoke();
            }
            catch
            {
                // Don't throw exceptions on event handlers
            }
            finally
            {
                NativeReboot();
            }
        }

        #region external methods declarations

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void NativeReboot();

        #endregion
    }
}
