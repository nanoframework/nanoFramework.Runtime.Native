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
        /// Gets the version information about the system.
        /// </summary>
        /// <value>A <see cref="Version"/> object that describes the version of the system.</value>
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
        /// Gets a string that contains information provided by the original equipment manufacturer (OEM) about this system.
        /// </summary>
        /// <value>A string that contains OEM information.</value>
        public static extern string OEMString
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents the original equipment manufacturer (OEM).
        /// </summary>
        /// <value>A byte that represents the OEM.</value>
        public static extern byte OEM
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents the product model.
        /// </summary>
        /// <value>A byte that represents the product model.</value>
        public static extern byte Model
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents the product's stock-keeping unit (SKU).
        /// </summary>
        /// <value>A ushort that represents the SKU.</value>
        public static extern ushort SKU
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a string that contains the target name.
        /// </summary>
        /// <value>A string that contains the target name.</value>
        public static extern string TargetName
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a string that contains the platform designation.
        /// </summary>
        /// <value>A string that contains the platform designation.</value>
        public static extern string Platform
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a <see cref="FloatingPoint"/> value that indicates the floating point support available on the target platform.
        /// </summary>
        /// <value>A <see cref="FloatingPoint"/> value that indicates the floating point support.</value>
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
        /// Specifies the floating point support options.
        /// </summary>
        public enum FloatingPoint
        {
            /// <summary>
            /// No floating point support.
            /// </summary>
            None = 0,

            /// <summary>
            /// Single precision floating point software emulated.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to the Math namespace using the <see cref="float"/> overloads.
            /// Calling the <see cref="double"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            SinglePrecisionSoftware = 1,

            /// <summary>
            /// Single precision floating point calculation supported by hardware unit.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to the Math namespace using the <see cref="float"/> overloads.
            /// Calling the <see cref="double"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            SinglePrecisionHardware = 2,

            /// <summary>
            /// Double precision floating point software emulated.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to the Math namespace using the <see cref="double"/> overloads.
            /// Calling the <see cref="float"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            DoublePrecisionSoftware = 3,

            /// <summary>
            /// Double precision floating point calculation supported by hardware unit.
            /// </summary>
            /// <remarks>
            /// The target platform supports calls to the Math namespace using the <see cref="double"/> overloads.
            /// Calling the <see cref="float"/> methods will throw a <see cref="NotSupportedException"/>.
            /// </remarks>
            DoublePrecisionHardware = 4,
        }

        #endregion
    }
}
