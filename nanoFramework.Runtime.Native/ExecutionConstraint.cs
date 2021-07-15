﻿//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// The exception that is thrown when an action is attempted that violates a constraint. 
    /// </summary>
    /// <remarks>When a ConstraintException exception is caught, if the <see cref="ExecutionConstraint"/> object that caused this exception has not been uninstalled, the catch block implementation has a small additional amount of time during which to handle the exception. 
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
        /// <summary>
        /// Creates a sub-thread within the calling thread, containing a constraint that requires the calling thread to complete an operation within a specified time period and at a specified priority level. 
        /// </summary>
        /// <param name="timeoutMilliseconds">The number of milliseconds before a <see cref="ConstraintException"/> exception is thrown. Note that the value -1 in this parameter indicates that the current constraint exception is to be uninstalled.</param>
        /// <param name="priority">The priority level of the calling thread.</param>
        /// <remarks>If the specified timeout expires before the thread has completed the operation, a <see cref="ConstraintException"/> exception is thrown. Note that the time that was set in the timeout parameter is standard clock time, not thread execution time.
        /// The priority level can only be raised for threads that already have a priority level higher than 0 (zero).
        /// </remarks>
        /// <exception cref="Exception">The timeout parameter is less than -1.</exception>
        /// <exception cref="Exception">The system is unable to identify the thread that is installing this constraint.</exception>
        /// <exception cref="Exception">The thread installing this constraint does not own the sub-thread that the constraint applies to.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static public void Install(int timeoutMilliseconds, int priority);
    }
}
