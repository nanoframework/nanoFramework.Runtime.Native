// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// The event handler delegate for the <see cref="Power.OnRebootEvent"/> event.
    /// </summary>
    public delegate void RebootEventHandler();

    /// <summary>
    /// Provides access to power management functionalities on target device.
    /// </summary>
    /// <remarks>
    /// This API is a general one common to all devices. There could be available target specific APIs providing other methods.
    /// </remarks>
    public class Power
    {
        /// <summary>
        /// This event notifies listeners prior to a device reboot.  The event handlers may have an execution
        /// constraint placed on them by the caller of the Reboot method.  Therefore, it is recommended that the event handlers
        /// be short atomic operations.
        /// </summary>
        public static event RebootEventHandler OnRebootEvent;


        /// <summary>
        /// The RebootDevice method enables the caller to force a reboot of the device.
        /// This method raises the OnRebootEvent.
        /// </summary>
        /// <remarks>
        /// If there are any handlers subscribing <see cref="OnRebootEvent"/> the reboot will happen only after all handlers complete their execution, no matter the time that takes.
        /// In case the developer want's to set a timeout for those to complete, use the alternative <see cref="RebootDevice(int)"/> call and 
        /// set an execution constrain.
        /// </remarks>
        public static void RebootDevice()
        {
            RebootDevice(-1);
        }

        /// <summary>
        /// The RebootDevice method enables the caller to force a reboot of the device.
        /// This method raises the OnRebootEvent.
        /// </summary>
        /// <param name="exeConstraintTimeout">Execution constraint timeout (in milliseconds) for
        /// the event handlers. If the event handlers take longer than the given value, then
        /// the handlers will be aborted and the reboot will be executed.
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
                // don't throw exceptions on event handlers
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
