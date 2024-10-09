// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides information about the system.
    /// </summary>
    public static class SystemInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetSystemVersion(
            out int major,
            out int minor,
            out int build,
            out int revision);

        /// <summary>
        /// Gets a string containing version information about this system. 
        /// </summary>
        public static Version Version
        {
            get
            {
                GetSystemVersion(
                    out int major,
                    out int minor,
                    out int build,
                    out int revision);

                return new Version(
                    major,
                    minor,
                    build,
                    revision);
            }
        }

        /// <summary>
        /// Gets a string that contains information provided by the equipment manufacturer (OEM) about this system.
        /// </summary>
        public static extern string OEMString
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents an original equipment manufacturer (OEM).
        /// </summary>
        public static extern byte OEM
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents a product model.
        /// </summary>
        public static extern byte Model
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents a product's stock-keeping unit (SKU).
        /// </summary>
        public static extern ushort SKU
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a string that contains the target name.
        /// </summary>
        public static extern string TargetName
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a string that contains the platform designation.
        /// </summary>
        public static extern string Platform
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a <see cref="FloatingPoint"/> value with the information regarding the floating point support available in the target platform.
        /// </summary>
        public static FloatingPoint FloatingPointSupport
        {
            get
            {
                return (FloatingPoint)GetNativeFloatingPointSupport();
            }
        }

        #region native calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte GetNativeFloatingPointSupport();

        #endregion

        #region Floating point support 

        /// <summary>
        /// Floating point options.
        /// </summary>
        public enum FloatingPoint
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// Single precision floating point software emulated.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to <see cref="Math"/> using the <see cref="float"/> overloads.
            /// Calling the <see cref="double"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            SinglePrecisionSoftware = 1,

            /// <summary>
            /// Single precision floating point calculation supported by hardware unit.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to <see cref="Math"/> using the <see cref="float"/> overloads.
            /// Calling the <see cref="double"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            SinglePrecisionHardware = 2,

            /// <summary>
            /// Double precision floating point software emulated.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to <see cref="Math"/> using the <see cref="double"/> overloads.
            /// Calling the <see cref="float"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            DoublePrecisionSoftware = 3,

            /// <summary>
            /// Double precision floating point calculation supported by hardware unit.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to Math namespace using the <see cref="double"/> overloads.
            /// Calling the <see cref="float"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            DoublePrecisionHardware = 4,
        }

        #endregion
    }
}
