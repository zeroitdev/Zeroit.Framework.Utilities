// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.UserPreferenceChangedEventArgs
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.Security.Permissions;
using Zeroit.Framework.Utilities;

namespace Zeroit.Framework.Utilities
{
    /// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.UserPreferenceChanged" /> event.</summary>
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class UserPreferenceChangedEventArgs : EventArgs
    {
        private readonly UserPreferenceCategory category;

        /// <summary>Gets the category of user preferences that has changed.</summary>
        /// <returns>One of the <see cref="T:Microsoft.Win32.UserPreferenceCategory" /> values that indicates the category of user preferences that has changed.</returns>
        public UserPreferenceCategory Category
        {
            get
            {
                return this.category;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.UserPreferenceChangedEventArgs" /> class using the specified user preference category identifier.</summary>
        /// <param name="category">One of the <see cref="T:Microsoft.Win32.UserPreferenceCategory" /> values that indicates the user preference category that has changed. </param>
        public UserPreferenceChangedEventArgs(UserPreferenceCategory category)
        {
            this.category = category;
        }
    }
}
