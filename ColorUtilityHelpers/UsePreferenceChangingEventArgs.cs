// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.UserPreferenceChangingEventArgs
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.Security.Permissions;


namespace Zeroit.Framework.Utilities
{
    /// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.UserPreferenceChanging" /> event.</summary>
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class UserPreferenceChangingEventArgs : EventArgs
    {
        private readonly UserPreferenceCategory category;

        /// <summary>Gets the category of user preferences that is changing.</summary>
        /// <returns>One of the <see cref="T:Microsoft.Win32.UserPreferenceCategory" /> values that indicates the category of user preferences that is changing.</returns>
        public UserPreferenceCategory Category
        {
            get
            {
                return this.category;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.UserPreferenceChangingEventArgs" /> class using the specified user preference category identifier.</summary>
        /// <param name="category">One of the <see cref="T:Microsoft.Win32.UserPreferenceCategory" /> values that indicate the user preference category that is changing. </param>
        public UserPreferenceChangingEventArgs(UserPreferenceCategory category)
        {
            this.category = category;
        }
    }
}