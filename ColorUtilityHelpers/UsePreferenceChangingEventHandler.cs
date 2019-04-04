// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.UserPreferenceChangingEventArgs
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.Security.Permissions;
using Microsoft.Win32;


namespace Zeroit.Framework.Utilities
{
    /// <summary>Represents the method that will handle the <see cref="E:Microsoft.Win32.SystemEvents.UserPreferenceChanging" /> event.</summary>
    /// <param name="sender">The source of the event. When this event is raised by the <see cref="T:Microsoft.Win32.SystemEvents" /> class, this object is always null. </param>
    /// <param name="e">A <see cref="T:Microsoft.Win32.UserPreferenceChangedEventArgs" /> that contains the event data. </param>
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    public delegate void UserPreferenceChangingEventHandler(object sender, UserPreferenceChangingEventArgs e);


    


}