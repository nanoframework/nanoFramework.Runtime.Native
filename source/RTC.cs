//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides a set of methods that help developers to manage the RTC (Real Time Clock) on the target device.
    /// </summary>
    public static class RTC
    {
        /// <summary>
        /// Sets the current system time and date.
        /// </summary>
        /// <param name="time"><see cref="System.DateTime"/> structure that contains the new system date and time.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        /// <remarks>This method is specific to nanoFramework. The actual availability of the resulting feature depends on the availability on target platform that's running the nanoCLR.</remarks>
        public static bool SetSystemTime(System.DateTime time)
        {
            return Native_RTC_SetSystemTime(time.Year, (byte)time.Month, (byte)time.Day, (byte)time.DayOfWeek, (byte)time.Hour, (byte)time.Minute, (byte)time.Second);
        }

        /// <summary>
        /// Sets the date and time for the next alarm that will wake-up the processor.
        /// </summary>
        /// <param name="time"><see cref="System.DateTime"/> to set.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        /// <remarks>This method is specific to nanoFramework. The actual availability of the resulting feature depends on the availability on target platform that's running the nanoCLR.</remarks>
        public static bool SetAlarm(System.DateTime time)
        {
            return Native_RTC_SetAlarm(time.Year, (byte)time.Month, (byte)time.Day, (byte)time.DayOfWeek, (byte)time.Hour, (byte)time.Minute, (byte)time.Second);
        }


        #region external methods declarations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool Native_RTC_SetSystemTime(int year, byte month, byte day, byte dayOfWeek, byte hours, byte minutes, byte seconds);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool Native_RTC_SetAlarm(int year, byte month, byte day, byte dayOfWeek, byte hours, byte minutes, byte seconds);

        #endregion
    }
}
