//
// Copyright (c) 2018 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Resources;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Helper class to access nanoFramework application managed resources.
    /// </summary>
    public static class ResourceUtility
    {
        private static WeakReference s_wr;

        static ResourceUtility()
        {
            s_wr = new WeakReference(typeof(ResourceUtility));
        }

        /// <summary>
        /// Gets the value of a specified <see cref="Object"/> resource for the current system culture.
        /// </summary>
        /// <param name="rm">The <see cref="ResourceManager"/> that contains the specified resources.</param>
        /// <param name="id">The integer identifier for the specified resource.</param>
        /// <returns>The value of the specified resource for the current system culture.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern public static object GetObject(System.Resources.ResourceManager rm, Enum id);

        /// <summary>
        /// Gets the value of a specified <see cref="Object"/> resource for the current system culture.
        /// </summary>
        /// <param name="rm">The <see cref="ResourceManager"/> that contains the specified resources.</param>
        /// <param name="id">The integer identifier for the specified resource.</param>
        /// <param name="offset">The offset for retrieving the value.</param>
        /// <param name="length">The length of the value to retrieve.</param>
        /// <returns>The value of the specified resource for the current system culture.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern public static object GetObject(System.Resources.ResourceManager rm, Enum id, int offset, int length);

        /// <summary>
        /// Retrieves the string representations of the specified resources.
        /// </summary>
        /// <param name="rm">The <see cref="ResourceManager"/> that contains the specified resources.</param>
        /// <param name="resource">An enumerated value that specifies the type of the resources for which you want to get the string representations.</param>
        /// <returns>The string representations of the specified resources.</returns>
        static public string[] GetDelimitedStringResources(ResourceManager rm, Enum resource)
        {
            string resources = (string)GetObject(rm, resource);

            return resources.Split('|');
        }

        /// <summary>
        /// Retrieves the string representation of a specified resource.
        /// </summary>
        /// <param name="rm">The <see cref="ResourceManager"/> that contains the specified resources.</param>
        /// <param name="resource">An enumerated value that specifies the type of the resources for which you want to get the string representations.</param>
        /// <param name="i">The index number of the resource (in the resource manager's resource collection) for which you want to get the string representation.</param>
        /// <returns>The string representations of the specified resource.</returns>
        static public string GetDelimitedStringResource(ResourceManager rm, Enum resource, int i)
        {
            string[] resources = GetDelimitedStringResources(rm, resource);

            return resources[i];
        }
    }
}
