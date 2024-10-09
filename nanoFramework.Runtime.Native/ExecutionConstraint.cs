// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// The exception that is thrown when an action is attempted that violates a constraint.
    /// </summary>
    /// <remarks>
    /// When a <see cref="ConstraintException"/> is caught, if the <see cref="ExecutionConstraint"/> object that caused this exception has not been uninstalled, 
    /// the <see langword="catch"/> block implementation has a small additional amount of time during which to handle the exception. 
    /// If this takes too long, the exception is re-thrown automatically.
    /// </remarks>
    public class ConstraintException : Exception
    {
    }

    /// <summary>
    /// Provides a method to require a thread to complete an operation within specific constraints.
    /// </summary>
    public static class ExecutionConstraint
    {
#pragma warning disable S4200 // Native methods should be wrapped

        /// <summary>
        /// Creates a sub-thread within the calling thread, containing a constraint that requires the calling thread to complete an operation within a specified time period and at a specified priority level.
        /// </summary>
        /// <param name="timeoutMilliseconds">
        /// The number of milliseconds before a <see cref="ConstraintException"/> is thrown. 
        /// A value of -1 indicates that the current constraint exception is to be uninstalled.
        /// </param>
        /// <param name="priority">The priority level of the calling thread.</param>
        /// <remarks>
        /// If the specified timeout expires before the thread has completed the operation, a <see cref="ConstraintException"/> is thrown. 
        /// Note that the time specified in the <paramref name="timeoutMilliseconds"/> parameter is standard clock time, not thread execution time.
        /// The priority level can only be raised for threads that already have a priority level higher than 0 (zero).
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="timeoutMilliseconds"/> is less than -1.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the system is unable to identify the thread that is installing this constraint.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the thread installing this constraint does not own the sub-thread that the constraint applies to.
        /// </exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Install(int timeoutMilliseconds, int priority);

#pragma warning restore S4200 // OK to call Native methods like this in .NET nanoFramework
    }
}
