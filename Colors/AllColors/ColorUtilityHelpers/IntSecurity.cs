// Decompiled with JetBrains decompiler
// Type: System.ComponentModel.IntSecurity
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System.IO;
using System.Security;
using System.Security.Permissions;

namespace System.ComponentModel
{
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
    internal static class IntSecurity
    {
        public static readonly CodeAccessPermission UnmanagedCode = (CodeAccessPermission)new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
        public static readonly CodeAccessPermission FullReflection = (CodeAccessPermission)new ReflectionPermission(PermissionState.Unrestricted);

        public static string UnsafeGetFullPath(string fileName)
        {
            new FileIOPermission(PermissionState.None)
            {
                AllFiles = FileIOPermissionAccess.PathDiscovery
            }.Assert();
            try
            {
                return Path.GetFullPath(fileName);
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
        }
    }
}
