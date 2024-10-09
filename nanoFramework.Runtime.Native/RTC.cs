// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides a set of methods that help developers to manage the Real Time Clock (RTC) on the target device.
    /// </summary>
    public static class Rtc
    {
        /// <summary>
        /// Sets the current system date and time.
        /// </summary>
        /// <param name="time">A <see cref="System.DateTime"/> structure that contains the new system date and time.</param>
        /// <returns><see langword="true"/> if the function succeeds; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method is specific to nanoFramework. The actual availability of this feature depends on the target platform running the nanoCLR.
        /// </remarks>
        public static bool SetSystemTime(System.DateTime time) => Native_RTC_SetSystemTime(
            time.Year,
            (byte)time.Month,
            (byte)time.Day,
            (byte)time.DayOfWeek,
            (byte)time.Hour,
            (byte)time.Minute,
            (byte)time.Second);

        #region external methods declarations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool Native_RTC_SetSystemTime(
            int year,
            byte month,
            byte day,
            byte dayOfWeek,
            byte hours,
            byte minutes,
            byte seconds);

        #endregion
    }
}
