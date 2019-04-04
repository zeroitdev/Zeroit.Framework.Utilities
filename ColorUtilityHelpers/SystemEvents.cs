using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace Zeroit.Framework.Utilities
{
    /// <summary>Provides access to system event notifications. This class cannot be inherited.</summary>
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    public sealed class SystemEvents
    {
        private static readonly object eventLockObject = new object();
        private static readonly object procLockObject = new object();
        private static Random randomTimerId = new Random();
        private static volatile bool registeredSessionNotification = false;
        private static volatile string className = (string)null;
        private static volatile int threadCallbackMessage = 0;
        private static volatile bool checkedThreadAffinity = false;
        private static volatile bool useEverettThreadAffinity = false;
        private static readonly object OnUserPreferenceChangingEvent = new object();
        private static readonly object OnUserPreferenceChangedEvent = new object();
        private static readonly object OnSessionEndingEvent = new object();
        private static readonly object OnSessionEndedEvent = new object();
        private static readonly object OnPowerModeChangedEvent = new object();
        private static readonly object OnLowMemoryEvent = new object();
        private static readonly object OnDisplaySettingsChangingEvent = new object();
        private static readonly object OnDisplaySettingsChangedEvent = new object();
        private static readonly object OnInstalledFontsChangedEvent = new object();
        private static readonly object OnTimeChangedEvent = new object();
        private static readonly object OnTimerElapsedEvent = new object();
        private static readonly object OnPaletteChangedEvent = new object();
        private static readonly object OnEventsThreadShutdownEvent = new object();
        private static readonly object OnSessionSwitchEvent = new object();
        private static volatile IntPtr processWinStation = IntPtr.Zero;
        private static volatile bool isUserInteractive = false;
        private static volatile string executablePath = (string)null;
        private static volatile SystemEvents systemEvents;
        private static volatile Thread windowThread;
        private static volatile ManualResetEvent eventWindowReady;
        private static volatile bool startupRecreates;
        private static volatile int domainQualifier;
        private static volatile NativeMethods.WNDCLASS staticwndclass;
        private static volatile IntPtr defWindowProc;
        private static volatile Queue threadCallbackList;
        private static volatile ManualResetEvent eventThreadTerminated;
        private const string everettThreadAffinityValue = "EnableSystemEventsThreadAffinityCompatibility";
        private volatile IntPtr windowHandle;
        private NativeMethods.WndProc windowProc;
        private NativeMethods.ConHndlr consoleHandler;
        private static Dictionary<object, List<SystemEvents.SystemEventInvokeInfo>> _handlers;
        private static volatile object appFileVersion;
        private static volatile Type mainType;

        private static bool UserInteractive
        {
            get
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    IntPtr zero = IntPtr.Zero;
                    IntPtr processWindowStation = UnsafeNativeMethods.GetProcessWindowStation();
                    if (processWindowStation != IntPtr.Zero && SystemEvents.processWinStation != processWindowStation)
                    {
                        SystemEvents.isUserInteractive = true;
                        int lpnLengthNeeded = 0;
                        NativeMethods.USEROBJECTFLAGS pvBuffer = new NativeMethods.USEROBJECTFLAGS();
                        if (UnsafeNativeMethods.GetUserObjectInformation(new HandleRef((object)null, processWindowStation), 1, pvBuffer, Marshal.SizeOf((object)pvBuffer), ref lpnLengthNeeded) && (pvBuffer.dwFlags & 1) == 0)
                            SystemEvents.isUserInteractive = false;
                        SystemEvents.processWinStation = processWindowStation;
                    }
                }
                else
                    SystemEvents.isUserInteractive = true;
                return SystemEvents.isUserInteractive;
            }
        }

        private NativeMethods.WNDCLASS WndClass
        {
            get
            {
                if (SystemEvents.staticwndclass == null)
                {
                    IntPtr moduleHandle = UnsafeNativeMethods.GetModuleHandle((string)null);
                    SystemEvents.className = string.Format((IFormatProvider)CultureInfo.InvariantCulture, ".NET-BroadcastEventWindow.{0}.{1}.{2}", new object[3]
                    {
                        (object) "4.0.0.0",
                        (object) Convert.ToString(AppDomain.CurrentDomain.GetHashCode(), 16),
                        (object) SystemEvents.domainQualifier
                    });
                    NativeMethods.WNDCLASS wndclass = new NativeMethods.WNDCLASS();
                    wndclass.hbrBackground = (IntPtr)6;
                    wndclass.style = 0;
                    this.windowProc = new NativeMethods.WndProc(this.WindowProc);
                    wndclass.lpszClassName = SystemEvents.className;
                    wndclass.lpfnWndProc = this.windowProc;
                    wndclass.hInstance = moduleHandle;
                    SystemEvents.staticwndclass = wndclass;
                }
                return SystemEvents.staticwndclass;
            }
        }

        private IntPtr DefWndProc
        {
            get
            {
                if (SystemEvents.defWindowProc == IntPtr.Zero)
                    SystemEvents.defWindowProc = UnsafeNativeMethods.GetProcAddress(new HandleRef((object)this, UnsafeNativeMethods.GetModuleHandle("user32.dll")), Marshal.SystemDefaultCharSize == 1 ? "DefWindowProcA" : "DefWindowProcW");
                return SystemEvents.defWindowProc;
            }
        }

        internal static bool UseEverettThreadAffinity
        {
            get
            {
                if (!SystemEvents.checkedThreadAffinity)
                {
                    lock (SystemEvents.eventLockObject)
                    {
                        if (!SystemEvents.checkedThreadAffinity)
                        {
                            SystemEvents.checkedThreadAffinity = true;
                            string format = "Software\\{0}\\{1}\\{2}";
                            try
                            {
                                new RegistryPermission(PermissionState.Unrestricted).Assert();
                                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Format((IFormatProvider)CultureInfo.CurrentCulture, format, new object[3]
                                {
                                    (object) SystemEvents.CompanyNameInternal,
                                    (object) SystemEvents.ProductNameInternal,
                                    (object) SystemEvents.ProductVersionInternal
                                }));
                                if (registryKey != null)
                                {
                                    object obj = registryKey.GetValue("EnableSystemEventsThreadAffinityCompatibility");
                                    if (obj != null)
                                    {
                                        if ((int)obj != 0)
                                            SystemEvents.useEverettThreadAffinity = true;
                                    }
                                }
                            }
                            catch (SecurityException ex)
                            {
                            }
                            catch (InvalidCastException ex)
                            {
                            }
                        }
                    }
                }
                return SystemEvents.useEverettThreadAffinity;
            }
        }

        private static string CompanyNameInternal
        {
            get
            {
                string str1 = (string)null;
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly != (Assembly)null)
                {
                    object[] customAttributes = entryAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                    if (customAttributes != null && customAttributes.Length != 0)
                        str1 = ((AssemblyCompanyAttribute)customAttributes[0]).Company;
                }
                if (str1 == null || str1.Length == 0)
                {
                    str1 = SystemEvents.GetAppFileVersionInfo().CompanyName;
                    if (str1 != null)
                        str1 = str1.Trim();
                }
                if (str1 == null || str1.Length == 0)
                {
                    Type appMainType = SystemEvents.GetAppMainType();
                    if (appMainType != (Type)null)
                    {
                        string str2 = appMainType.Namespace;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            int length = str2.IndexOf(".", StringComparison.Ordinal);
                            str1 = length == -1 ? str2 : str2.Substring(0, length);
                        }
                        else
                            str1 = SystemEvents.ProductNameInternal;
                    }
                }
                return str1;
            }
        }

        private static string ProductNameInternal
        {
            get
            {
                string str1 = (string)null;
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly != (Assembly)null)
                {
                    object[] customAttributes = entryAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                    if (customAttributes != null && customAttributes.Length != 0)
                        str1 = ((AssemblyProductAttribute)customAttributes[0]).Product;
                }
                if (str1 == null || str1.Length == 0)
                {
                    str1 = SystemEvents.GetAppFileVersionInfo().ProductName;
                    if (str1 != null)
                        str1 = str1.Trim();
                }
                if (str1 == null || str1.Length == 0)
                {
                    Type appMainType = SystemEvents.GetAppMainType();
                    if (appMainType != (Type)null)
                    {
                        string str2 = appMainType.Namespace;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            int num = str2.LastIndexOf(".", StringComparison.Ordinal);
                            str1 = num == -1 || num >= str2.Length - 1 ? str2 : str2.Substring(num + 1);
                        }
                        else
                            str1 = appMainType.Name;
                    }
                }
                return str1;
            }
        }

        private static string ProductVersionInternal
        {
            get
            {
                string str = (string)null;
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly != (Assembly)null)
                {
                    object[] customAttributes = entryAssembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                    if (customAttributes != null && customAttributes.Length != 0)
                        str = ((AssemblyInformationalVersionAttribute)customAttributes[0]).InformationalVersion;
                }
                if (str == null || str.Length == 0)
                {
                    str = SystemEvents.GetAppFileVersionInfo().ProductVersion;
                    if (str != null)
                        str = str.Trim();
                }
                if (str == null || str.Length == 0)
                    str = "1.0.0.0";
                return str;
            }
        }

        private static string ExecutablePath
        {
            get
            {
                if (SystemEvents.executablePath == null)
                {
                    Assembly entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly == (Assembly)null)
                    {
                        StringBuilder buffer = new StringBuilder(260);
                        UnsafeNativeMethods.GetModuleFileName(NativeMethods.NullHandleRef, buffer, buffer.Capacity);
                        SystemEvents.executablePath = IntSecurity.UnsafeGetFullPath(buffer.ToString());
                    }
                    else
                    {
                        string escapedCodeBase = entryAssembly.EscapedCodeBase;
                        Uri uri = new Uri(escapedCodeBase);
                        SystemEvents.executablePath = !(uri.Scheme == "file") ? uri.ToString() : NativeMethods.GetLocalPath(escapedCodeBase);
                    }
                }
                if (new Uri(SystemEvents.executablePath).Scheme == "file")
                    new FileIOPermission(FileIOPermissionAccess.PathDiscovery, SystemEvents.executablePath).Demand();
                return SystemEvents.executablePath;
            }
        }

        /// <summary>Occurs when the display settings are changing.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event EventHandler DisplaySettingsChanging
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnDisplaySettingsChangingEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnDisplaySettingsChangingEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user changes the display settings.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event EventHandler DisplaySettingsChanged
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnDisplaySettingsChangedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnDisplaySettingsChangedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs before the thread that listens for system events is terminated.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event EventHandler EventsThreadShutdown
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnEventsThreadShutdownEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnEventsThreadShutdownEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user adds fonts to or removes fonts from the system.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event EventHandler InstalledFontsChanged
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnInstalledFontsChangedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnInstalledFontsChangedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the system is running out of available RAM.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        [Obsolete("This event has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler LowMemory
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, true);
                SystemEvents.AddEventHandler(SystemEvents.OnLowMemoryEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnLowMemoryEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user switches to an application that uses a different palette.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event EventHandler PaletteChanged
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnPaletteChangedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnPaletteChangedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user suspends or resumes the system.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event PowerModeChangedEventHandler PowerModeChanged
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, true);
                SystemEvents.AddEventHandler(SystemEvents.OnPowerModeChangedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnPowerModeChangedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user is logging off or shutting down the system.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event SessionEndedEventHandler SessionEnded
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, false);
                SystemEvents.AddEventHandler(SystemEvents.OnSessionEndedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnSessionEndedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user is trying to log off or shut down the system.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event SessionEndingEventHandler SessionEnding
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, false);
                SystemEvents.AddEventHandler(SystemEvents.OnSessionEndingEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnSessionEndingEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the currently logged-in user has changed.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event SessionSwitchEventHandler SessionSwitch
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, true);
                SystemEvents.EnsureRegisteredSessionNotification();
                SystemEvents.AddEventHandler(SystemEvents.OnSessionSwitchEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnSessionSwitchEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when the user changes the time on the system clock.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event EventHandler TimeChanged
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, false);
                SystemEvents.AddEventHandler(SystemEvents.OnTimeChangedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnTimeChangedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when a windows timer interval has expired.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event TimerElapsedEventHandler TimerElapsed
        {
            add
            {
                SystemEvents.EnsureSystemEvents(true, false);
                SystemEvents.AddEventHandler(SystemEvents.OnTimerElapsedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnTimerElapsedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when a user preference has changed.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event UserPreferenceChangedEventHandler UserPreferenceChanged
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnUserPreferenceChangedEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnUserPreferenceChangedEvent, (Delegate)value);
            }
        }

        /// <summary>Occurs when a user preference is changing.</summary>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static event UserPreferenceChangingEventHandler UserPreferenceChanging
        {
            add
            {
                SystemEvents.AddEventHandler(SystemEvents.OnUserPreferenceChangingEvent, (Delegate)value);
            }
            remove
            {
                SystemEvents.RemoveEventHandler(SystemEvents.OnUserPreferenceChangingEvent, (Delegate)value);
            }
        }

        private SystemEvents()
        {
        }

        private static void AddEventHandler(object key, Delegate value)
        {
            lock (SystemEvents.eventLockObject)
            {
                if (SystemEvents._handlers == null)
                {
                    SystemEvents._handlers = new Dictionary<object, List<SystemEvents.SystemEventInvokeInfo>>();
                    SystemEvents.EnsureSystemEvents(false, false);
                }
                List<SystemEvents.SystemEventInvokeInfo> systemEventInvokeInfoList1;
                List<SystemEvents.SystemEventInvokeInfo> systemEventInvokeInfoList2;
                if (!SystemEvents._handlers.TryGetValue(key, out systemEventInvokeInfoList1))
                {
                    systemEventInvokeInfoList2 = new List<SystemEvents.SystemEventInvokeInfo>();
                    SystemEvents._handlers[key] = systemEventInvokeInfoList2;
                }
                else
                    systemEventInvokeInfoList2 = SystemEvents._handlers[key];
                systemEventInvokeInfoList2.Add(new SystemEvents.SystemEventInvokeInfo(value));
            }
        }

        private int ConsoleHandlerProc(int signalType)
        {
            if (signalType != 5)
            {
                if (signalType == 6)
                    this.OnSessionEnded((IntPtr)1, (IntPtr)0);
            }
            else
                this.OnSessionEnded((IntPtr)1, (IntPtr)int.MinValue);
            return 0;
        }

        private void BumpQualifier()
        {
            SystemEvents.staticwndclass = (NativeMethods.WNDCLASS)null;
            ++SystemEvents.domainQualifier;
        }

        private IntPtr CreateBroadcastWindow()
        {
            NativeMethods.WNDCLASS_I wc = new NativeMethods.WNDCLASS_I();
            IntPtr moduleHandle = UnsafeNativeMethods.GetModuleHandle((string)null);
            if (!UnsafeNativeMethods.GetClassInfo(new HandleRef((object)this, moduleHandle), this.WndClass.lpszClassName, wc))
            {
                if ((int)UnsafeNativeMethods.RegisterClass(this.WndClass) == 0)
                {
                    this.windowProc = (NativeMethods.WndProc)null;
                    return IntPtr.Zero;
                }
            }
            else if (wc.lpfnWndProc == this.DefWndProc)
            {
                short num = 0;
                if ((int)UnsafeNativeMethods.UnregisterClass(this.WndClass.lpszClassName, new HandleRef((object)null, UnsafeNativeMethods.GetModuleHandle((string)null))) != 0)
                    num = UnsafeNativeMethods.RegisterClass(this.WndClass);
                if ((int)num == 0)
                {
                    do
                    {
                        this.BumpQualifier();
                    }
                    while ((int)UnsafeNativeMethods.RegisterClass(this.WndClass) == 0 && Marshal.GetLastWin32Error() == 1410);
                }
            }
            return UnsafeNativeMethods.CreateWindowEx(0, this.WndClass.lpszClassName, this.WndClass.lpszClassName, int.MinValue, 0, 0, 0, 0, NativeMethods.NullHandleRef, NativeMethods.NullHandleRef, new HandleRef((object)this, moduleHandle), (object)null);
        }

        /// <summary>Creates a new window timer associated with the system events window.</summary>
        /// <param name="interval">Specifies the interval between timer notifications, in milliseconds.</param>
        /// <returns>The ID of the new timer.</returns>
        /// <exception cref="T:System.ArgumentException">The interval is less than or equal to zero. </exception>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed, or the attempt to create the timer did not succeed.</exception>
        public static IntPtr CreateTimer(int interval)
        {
            if (interval <= 0)
                throw new ArgumentException("InvalidLowBoundArgument", Convert.ToString((object)"interval") + (object)interval.ToString((IFormatProvider)Thread.CurrentThread.CurrentCulture) + (object)"0".ToString());
            SystemEvents.EnsureSystemEvents(true, true);
            IntPtr num = UnsafeNativeMethods.SendMessage(new HandleRef((object)SystemEvents.systemEvents, SystemEvents.systemEvents.windowHandle), 1025, (IntPtr)interval, IntPtr.Zero);
            if (num == IntPtr.Zero)
                throw new ExternalException("ErrorCreateTimer");
            return num;
        }

        private void Dispose()
        {
            if (this.windowHandle != IntPtr.Zero)
            {
                if (SystemEvents.registeredSessionNotification)
                    UnsafeNativeMethods.WTSUnRegisterSessionNotification(new HandleRef((object)SystemEvents.systemEvents, SystemEvents.systemEvents.windowHandle));
                IntPtr windowHandle = this.windowHandle;
                this.windowHandle = IntPtr.Zero;
                HandleRef handleRef = new HandleRef((object)this, windowHandle);
                if (UnsafeNativeMethods.IsWindow(handleRef) && this.DefWndProc != IntPtr.Zero)
                {
                    UnsafeNativeMethods.SetWindowLong(handleRef, -4, new HandleRef((object)this, this.DefWndProc));
                    UnsafeNativeMethods.SetClassLong(handleRef, -24, this.DefWndProc);
                }
                if (UnsafeNativeMethods.IsWindow(handleRef) && !UnsafeNativeMethods.DestroyWindow(handleRef))
                {
                    UnsafeNativeMethods.PostMessage(handleRef, 16, IntPtr.Zero, IntPtr.Zero);
                }
                else
                {
                    IntPtr moduleHandle = UnsafeNativeMethods.GetModuleHandle((string)null);
                    int num = (int)UnsafeNativeMethods.UnregisterClass(SystemEvents.className, new HandleRef((object)this, moduleHandle));
                }
            }
            if (this.consoleHandler == null)
                return;
            UnsafeNativeMethods.SetConsoleCtrlHandler(this.consoleHandler, 0);
            this.consoleHandler = (NativeMethods.ConHndlr)null;
        }

        private static void EnsureSystemEvents(bool requireHandle, bool throwOnRefusal)
        {
            if (SystemEvents.systemEvents != null)
                return;
            lock (SystemEvents.procLockObject)
            {
                if (SystemEvents.systemEvents != null)
                    return;
                if (Thread.GetDomain().GetData(".appDomain") != null)
                {
                    if (throwOnRefusal)
                        throw new InvalidOperationException("ErrorSystemEventsNotSupported");
                }
                else
                {
                    if (!SystemEvents.UserInteractive || Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                    {
                        SystemEvents.systemEvents = new SystemEvents();
                        SystemEvents.systemEvents.Initialize();
                    }
                    else
                    {
                        SystemEvents.eventWindowReady = new ManualResetEvent(false);
                        SystemEvents.systemEvents = new SystemEvents();
                        SystemEvents.windowThread = new Thread(new ThreadStart(SystemEvents.systemEvents.WindowThreadProc));
                        SystemEvents.windowThread.IsBackground = true;
                        SystemEvents.windowThread.Name = ".NET SystemEvents";
                        SystemEvents.windowThread.Start();
                        SystemEvents.eventWindowReady.WaitOne();
                    }
                    if (requireHandle && SystemEvents.systemEvents.windowHandle == IntPtr.Zero)
                        throw new ExternalException("ErrorCreateSystemEvents");
                    SystemEvents.startupRecreates = false;
                }
            }
        }

        private static void EnsureRegisteredSessionNotification()
        {
            if (SystemEvents.registeredSessionNotification)
                return;
            IntPtr handle = SafeNativeMethods.LoadLibrary("wtsapi32.dll");
            if (!(handle != IntPtr.Zero))
                return;
            UnsafeNativeMethods.WTSRegisterSessionNotification(new HandleRef((object)SystemEvents.systemEvents, SystemEvents.systemEvents.windowHandle), 0);
            SystemEvents.registeredSessionNotification = true;
            SafeNativeMethods.FreeLibrary(new HandleRef((object)null, handle));
        }

        private UserPreferenceCategory GetUserPreferenceCategory(int msg, IntPtr wParam, IntPtr lParam)
        {
            UserPreferenceCategory preferenceCategory = UserPreferenceCategory.General;
            if (msg == 26)
            {
                if (lParam != IntPtr.Zero && Marshal.PtrToStringAuto(lParam).Equals("Policy"))
                    preferenceCategory = UserPreferenceCategory.Policy;
                else if (lParam != IntPtr.Zero && Marshal.PtrToStringAuto(lParam).Equals("intl"))
                {
                    preferenceCategory = UserPreferenceCategory.Locale;
                }
                else
                {
                    switch ((int)wParam)
                    {
                        case 4159:
                        case 8193:
                        case 8195:
                        case 8197:
                        case 8199:
                        case 4097:
                        case 4101:
                        case 4103:
                        case 4105:
                        case 4107:
                        case 4109:
                        case 111:
                        case 6:
                        case 37:
                        case 42:
                        case 44:
                        case 73:
                        case 76:
                        case 77:
                            preferenceCategory = UserPreferenceCategory.Window;
                            break;
                        case 4099:
                        case 4115:
                        case 4117:
                        case 28:
                        case 107:
                            preferenceCategory = UserPreferenceCategory.Menu;
                            break;
                        case 4111:
                        case 4119:
                        case 4121:
                        case 4123:
                        case 113:
                        case 4:
                        case 29:
                        case 30:
                        case 32:
                        case 33:
                        case 93:
                        case 96:
                        case 101:
                        case 103:
                        case 105:
                            preferenceCategory = UserPreferenceCategory.Mouse;
                            break;
                        case 11:
                        case 23:
                        case 69:
                        case 91:
                            preferenceCategory = UserPreferenceCategory.Keyboard;
                            break;
                        case 13:
                        case 24:
                        case 26:
                        case 34:
                        case 46:
                        case 88:
                            preferenceCategory = UserPreferenceCategory.Icon;
                            break;
                        case 15:
                        case 17:
                        case 97:
                            preferenceCategory = UserPreferenceCategory.Screensaver;
                            break;
                        case 19:
                        case 20:
                        case 21:
                        case 47:
                        case 75:
                        case 87:
                            preferenceCategory = UserPreferenceCategory.Desktop;
                            break;
                        case 51:
                        case 53:
                        case 55:
                        case 57:
                        case 59:
                        case 61:
                        case 63:
                        case 65:
                        case 67:
                        case 71:
                            preferenceCategory = UserPreferenceCategory.Accessibility;
                            break;
                        case 81:
                        case 82:
                        case 85:
                        case 86:
                            preferenceCategory = UserPreferenceCategory.Power;
                            break;
                    }
                }
            }
            else if (msg == 21)
                preferenceCategory = UserPreferenceCategory.Color;
            return preferenceCategory;
        }

        private void Initialize()
        {
            this.consoleHandler = new NativeMethods.ConHndlr(this.ConsoleHandlerProc);
            if (!UnsafeNativeMethods.SetConsoleCtrlHandler(this.consoleHandler, 1))
                this.consoleHandler = (NativeMethods.ConHndlr)null;
            this.windowHandle = this.CreateBroadcastWindow();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(SystemEvents.Shutdown);
            AppDomain.CurrentDomain.DomainUnload += new EventHandler(SystemEvents.Shutdown);
        }

        private void InvokeMarshaledCallbacks()
        {
            Delegate @delegate = (Delegate)null;
            lock (SystemEvents.threadCallbackList)
            {
                if (SystemEvents.threadCallbackList.Count > 0)
                    @delegate = (Delegate)SystemEvents.threadCallbackList.Dequeue();
            }
            while ((object)@delegate != null)
            {
                try
                {
                    EventHandler eventHandler = @delegate as EventHandler;
                    if (eventHandler != null)
                        eventHandler((object)null, EventArgs.Empty);
                    else
                        @delegate.DynamicInvoke();
                }
                catch (Exception ex)
                {
                }
                lock (SystemEvents.threadCallbackList)
                    @delegate = SystemEvents.threadCallbackList.Count <= 0 ? (Delegate)null : (Delegate)SystemEvents.threadCallbackList.Dequeue();
            }
        }

        /// <summary>Invokes the specified delegate using the thread that listens for system events.</summary>
        /// <param name="method">A delegate to invoke using the thread that listens for system events. </param>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
        public static void InvokeOnEventsThread(Delegate method)
        {
            SystemEvents.EnsureSystemEvents(true, true);
            if (SystemEvents.threadCallbackList == null)
            {
                lock (SystemEvents.eventLockObject)
                {
                    if (SystemEvents.threadCallbackList == null)
                    {
                        SystemEvents.threadCallbackMessage = SafeNativeMethods.RegisterWindowMessage("SystemEventsThreadCallbackMessage");
                        SystemEvents.threadCallbackList = new Queue();
                    }
                }
            }
            lock (SystemEvents.threadCallbackList)
                SystemEvents.threadCallbackList.Enqueue((object)method);
            UnsafeNativeMethods.PostMessage(new HandleRef((object)SystemEvents.systemEvents, SystemEvents.systemEvents.windowHandle), SystemEvents.threadCallbackMessage, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>Terminates the timer specified by the given id.</summary>
        /// <param name="timerId">The ID of the timer to terminate. </param>
        /// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed, or the attempt to terminate the timer did not succeed. </exception>
        public static void KillTimer(IntPtr timerId)
        {
            SystemEvents.EnsureSystemEvents(true, true);
            if (SystemEvents.systemEvents.windowHandle != IntPtr.Zero && (int)UnsafeNativeMethods.SendMessage(new HandleRef((object)SystemEvents.systemEvents, SystemEvents.systemEvents.windowHandle), 1026, timerId, IntPtr.Zero) == 0)
                throw new ExternalException("ErrorKillTimer");
        }

        private IntPtr OnCreateTimer(IntPtr wParam)
        {
            IntPtr handle = (IntPtr)SystemEvents.randomTimerId.Next();
            if (!(UnsafeNativeMethods.SetTimer(new HandleRef((object)this, this.windowHandle), new HandleRef((object)this, handle), (int)wParam, NativeMethods.NullHandleRef) == IntPtr.Zero))
                return handle;
            return IntPtr.Zero;
        }

        private void OnDisplaySettingsChanging()
        {
            SystemEvents.RaiseEvent(SystemEvents.OnDisplaySettingsChangingEvent, new object[2]
            {
                (object) this,
                (object) EventArgs.Empty
            });
        }

        private void OnDisplaySettingsChanged()
        {
            SystemEvents.RaiseEvent(SystemEvents.OnDisplaySettingsChangedEvent, new object[2]
            {
                (object) this,
                (object) EventArgs.Empty
            });
        }

        private void OnGenericEvent(object eventKey)
        {
            SystemEvents.RaiseEvent(eventKey, new object[2]
            {
                (object) this,
                (object) EventArgs.Empty
            });
        }

        private void OnShutdown(object eventKey)
        {
            SystemEvents.RaiseEvent(false, eventKey, (object)this, (object)EventArgs.Empty);
        }

        private bool OnKillTimer(IntPtr wParam)
        {
            return UnsafeNativeMethods.KillTimer(new HandleRef((object)this, this.windowHandle), new HandleRef((object)this, wParam));
        }

        private void OnPowerModeChanged(IntPtr wParam)
        {
            PowerModes mode;
            switch ((int)wParam)
            {
                case 4:
                case 5:
                    mode = PowerModes.Suspend;
                    break;
                case 6:
                case 7:
                case 8:
                    mode = PowerModes.Resume;
                    break;
                case 9:
                case 10:
                case 11:
                    mode = PowerModes.StatusChange;
                    break;
                default:
                    return;
            }
            SystemEvents.RaiseEvent(SystemEvents.OnPowerModeChangedEvent, new object[2]
            {
                (object) this,
                (object) new PowerModeChangedEventArgs(mode)
            });
        }

        private void OnSessionEnded(IntPtr wParam, IntPtr lParam)
        {
            if (!(wParam != (IntPtr)0))
                return;
            SessionEndReasons reason = SessionEndReasons.SystemShutdown;
            if (((int)(long)lParam & int.MinValue) != 0)
                reason = SessionEndReasons.Logoff;
            SessionEndedEventArgs sessionEndedEventArgs = new SessionEndedEventArgs(reason);
            SystemEvents.RaiseEvent(SystemEvents.OnSessionEndedEvent, new object[2]
            {
                (object) this,
                (object) sessionEndedEventArgs
            });
        }

        private int OnSessionEnding(IntPtr lParam)
        {
            SessionEndReasons reason = SessionEndReasons.SystemShutdown;
            if (((long)lParam & (long)int.MinValue) != 0L)
                reason = SessionEndReasons.Logoff;
            SessionEndingEventArgs sessionEndingEventArgs = new SessionEndingEventArgs(reason);
            SystemEvents.RaiseEvent(SystemEvents.OnSessionEndingEvent, new object[2]
            {
                (object) this,
                (object) sessionEndingEventArgs
            });
            return sessionEndingEventArgs.Cancel ? 0 : 1;
        }

        private void OnSessionSwitch(int wParam)
        {
            SessionSwitchEventArgs sessionSwitchEventArgs = new SessionSwitchEventArgs((SessionSwitchReason)wParam);
            SystemEvents.RaiseEvent(SystemEvents.OnSessionSwitchEvent, new object[2]
            {
                (object) this,
                (object) sessionSwitchEventArgs
            });
        }

        private void OnThemeChanged()
        {
            SystemEvents.RaiseEvent(SystemEvents.OnUserPreferenceChangingEvent, new object[2]
            {
                (object) this,
                (object) new UserPreferenceChangingEventArgs(UserPreferenceCategory.VisualStyle)
            });
            UserPreferenceCategory category1 = UserPreferenceCategory.Window;
            RaiseEvent(SystemEvents.OnUserPreferenceChangedEvent, new object[2]
            {
                (object) this,
                (object) new UserPreferenceChangedEventArgs(category1)
            });
            UserPreferenceCategory category2 = UserPreferenceCategory.VisualStyle;
            SystemEvents.RaiseEvent(SystemEvents.OnUserPreferenceChangedEvent, new object[2]
            {
                (object) this,
                (object) new UserPreferenceChangedEventArgs(category2)
            });
        }

        private void OnUserPreferenceChanged(int msg, IntPtr wParam, IntPtr lParam)
        {
            UserPreferenceCategory preferenceCategory = this.GetUserPreferenceCategory(msg, wParam, lParam);
            SystemEvents.RaiseEvent(SystemEvents.OnUserPreferenceChangedEvent, new object[2]
            {
                (object) this,
                (object) new UserPreferenceChangedEventArgs(preferenceCategory)
            });
        }

        private void OnUserPreferenceChanging(int msg, IntPtr wParam, IntPtr lParam)
        {
            UserPreferenceCategory preferenceCategory = this.GetUserPreferenceCategory(msg, wParam, lParam);
            SystemEvents.RaiseEvent(SystemEvents.OnUserPreferenceChangingEvent, new object[2]
            {
                (object) this,
                (object) new UserPreferenceChangingEventArgs(preferenceCategory)
            });
        }

        private void OnTimerElapsed(IntPtr wParam)
        {
            SystemEvents.RaiseEvent(SystemEvents.OnTimerElapsedEvent, new object[2]
            {
                (object) this,
                (object) new TimerElapsedEventArgs(wParam)
            });
        }

        private static FileVersionInfo GetAppFileVersionInfo()
        {
            if (SystemEvents.appFileVersion == null)
            {
                Type appMainType = SystemEvents.GetAppMainType();
                if (appMainType != (Type)null)
                {
                    new FileIOPermission(PermissionState.None)
                    {
                        AllFiles = (FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery)
                    }.Assert();
                    try
                    {
                        SystemEvents.appFileVersion = (object)FileVersionInfo.GetVersionInfo(appMainType.Module.FullyQualifiedName);
                    }
                    finally
                    {
                        CodeAccessPermission.RevertAssert();
                    }
                }
                else
                    SystemEvents.appFileVersion = (object)FileVersionInfo.GetVersionInfo(SystemEvents.ExecutablePath);
            }
            return (FileVersionInfo)SystemEvents.appFileVersion;
        }

        private static Type GetAppMainType()
        {
            if (SystemEvents.mainType == (Type)null)
            {
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly != (Assembly)null)
                    SystemEvents.mainType = entryAssembly.EntryPoint.ReflectedType;
            }
            return SystemEvents.mainType;
        }

        private static void RaiseEvent(object key, params object[] args)
        {
            SystemEvents.RaiseEvent(true, key, args);
        }

        private static void RaiseEvent(bool checkFinalization, object key, params object[] args)
        {
            if (checkFinalization && AppDomain.CurrentDomain.IsFinalizingForUnload())
                return;
            SystemEvents.SystemEventInvokeInfo[] systemEventInvokeInfoArray = (SystemEvents.SystemEventInvokeInfo[])null;
            lock (SystemEvents.eventLockObject)
            {
                if (SystemEvents._handlers != null)
                {
                    if (SystemEvents._handlers.ContainsKey(key))
                    {
                        List<SystemEvents.SystemEventInvokeInfo> handler = SystemEvents._handlers[key];
                        if (handler != null)
                            systemEventInvokeInfoArray = handler.ToArray();
                    }
                }
            }
            if (systemEventInvokeInfoArray == null)
                return;
            for (int index = 0; index < systemEventInvokeInfoArray.Length; ++index)
            {
                try
                {
                    systemEventInvokeInfoArray[index].Invoke(checkFinalization, args);
                    systemEventInvokeInfoArray[index] = (SystemEvents.SystemEventInvokeInfo)null;
                }
                catch (Exception ex)
                {
                }
            }
            lock (SystemEvents.eventLockObject)
            {
                List<SystemEvents.SystemEventInvokeInfo> systemEventInvokeInfoList = (List<SystemEvents.SystemEventInvokeInfo>)null;
                for (int index = 0; index < systemEventInvokeInfoArray.Length; ++index)
                {
                    SystemEvents.SystemEventInvokeInfo systemEventInvokeInfo = systemEventInvokeInfoArray[index];
                    if (systemEventInvokeInfo != null)
                    {
                        if (systemEventInvokeInfoList == null && !SystemEvents._handlers.TryGetValue(key, out systemEventInvokeInfoList))
                            break;
                        systemEventInvokeInfoList.Remove(systemEventInvokeInfo);
                    }
                }
            }
        }

        private static void RemoveEventHandler(object key, Delegate value)
        {
            lock (SystemEvents.eventLockObject)
            {
                if (SystemEvents._handlers == null || !SystemEvents._handlers.ContainsKey(key))
                    return;
                SystemEvents._handlers[key].Remove(new SystemEvents.SystemEventInvokeInfo(value));
            }
        }

        private static void Startup()
        {
            if (!SystemEvents.startupRecreates)
                return;
            SystemEvents.EnsureSystemEvents(false, false);
        }

        private static void Shutdown()
        {
            if (SystemEvents.systemEvents == null || !(SystemEvents.systemEvents.windowHandle != IntPtr.Zero))
                return;
            lock (SystemEvents.procLockObject)
            {
                if (SystemEvents.systemEvents == null)
                    return;
                SystemEvents.startupRecreates = true;
                if (SystemEvents.windowThread != null)
                {
                    SystemEvents.eventThreadTerminated = new ManualResetEvent(false);
                    UnsafeNativeMethods.PostMessage(new HandleRef((object)SystemEvents.systemEvents, SystemEvents.systemEvents.windowHandle), 18, IntPtr.Zero, IntPtr.Zero);
                    SystemEvents.eventThreadTerminated.WaitOne();
                    SystemEvents.windowThread.Join();
                }
                else
                {
                    SystemEvents.systemEvents.Dispose();
                    SystemEvents.systemEvents = (SystemEvents)null;
                }
            }
        }

        [PrePrepareMethod]
        private static void Shutdown(object sender, EventArgs e)
        {
            SystemEvents.Shutdown();
        }

        private IntPtr WindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case 8467:
                    this.OnTimerElapsed(wParam);
                    break;
                case 8977:
                    this.OnGenericEvent(SystemEvents.OnPaletteChangedEvent);
                    break;
                case 8986:
                    this.OnThemeChanged();
                    break;
                case 8257:
                    this.OnGenericEvent(SystemEvents.OnLowMemoryEvent);
                    break;
                case 8318:
                    this.OnDisplaySettingsChanging();
                    this.OnDisplaySettingsChanged();
                    break;
                case 1026:
                    return (IntPtr)(this.OnKillTimer(wParam) ? 1 : 0);
                case 8213:
                    this.OnUserPreferenceChanging(msg - 8192, wParam, lParam);
                    this.OnUserPreferenceChanged(msg - 8192, wParam, lParam);
                    break;
                case 8218:
                    try
                    {
                        this.OnUserPreferenceChanging(msg - 8192, wParam, lParam);
                        this.OnUserPreferenceChanged(msg - 8192, wParam, lParam);
                        break;
                    }
                    finally
                    {
                        try
                        {
                            if (lParam != IntPtr.Zero)
                                Marshal.FreeHGlobal(lParam);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                case 8221:
                    this.OnGenericEvent(SystemEvents.OnInstalledFontsChangedEvent);
                    break;
                case 8222:
                    this.OnGenericEvent(SystemEvents.OnTimeChangedEvent);
                    break;
                case 794:
                case 785:
                case 126:
                case 275:
                case 29:
                case 30:
                case 65:
                case 21:
                    UnsafeNativeMethods.PostMessage(new HandleRef((object)this, this.windowHandle), 8192 + msg, wParam, lParam);
                    break;
                case 1025:
                    return this.OnCreateTimer(wParam);
                case 536:
                    this.OnPowerModeChanged(wParam);
                    break;
                case 689:
                    this.OnSessionSwitch((int)wParam);
                    break;
                case 22:
                    this.OnSessionEnded(wParam, lParam);
                    break;
                case 26:
                    IntPtr lparam = lParam;
                    if (lParam != IntPtr.Zero)
                    {
                        string stringAuto = Marshal.PtrToStringAuto(lParam);
                        if (stringAuto != null)
                            lparam = Marshal.StringToHGlobalAuto(stringAuto);
                    }
                    UnsafeNativeMethods.PostMessage(new HandleRef((object)this, this.windowHandle), 8192 + msg, wParam, lparam);
                    break;
                case 17:
                    return (IntPtr)this.OnSessionEnding(lParam);
                default:
                    if (msg == SystemEvents.threadCallbackMessage && msg != 0)
                    {
                        this.InvokeMarshaledCallbacks();
                        return IntPtr.Zero;
                    }
                    break;
            }
            return UnsafeNativeMethods.DefWindowProc(hWnd, msg, wParam, lParam);
        }

        private void WindowThreadProc()
        {
            try
            {
                this.Initialize();
                SystemEvents.eventWindowReady.Set();
                if (this.windowHandle != IntPtr.Zero)
                {
                    NativeMethods.MSG msg = new NativeMethods.MSG();
                    bool flag = true;
                    while (flag)
                    {
                        if (UnsafeNativeMethods.MsgWaitForMultipleObjectsEx(0, IntPtr.Zero, 100, (int)byte.MaxValue, 4) == 258)
                        {
                            Thread.Sleep(1);
                        }
                        else
                        {
                            while (UnsafeNativeMethods.PeekMessage(ref msg, NativeMethods.NullHandleRef, 0, 0, 1))
                            {
                                if (msg.message == 18)
                                {
                                    flag = false;
                                    break;
                                }
                                UnsafeNativeMethods.TranslateMessage(ref msg);
                                UnsafeNativeMethods.DispatchMessage(ref msg);
                            }
                        }
                    }
                }
                this.OnShutdown(SystemEvents.OnEventsThreadShutdownEvent);
            }
            catch (Exception ex)
            {
                SystemEvents.eventWindowReady.Set();
                if (!(ex is ThreadInterruptedException))
                {
                    ThreadAbortException threadAbortException = ex as ThreadAbortException;
                }
            }
            this.Dispose();
            if (SystemEvents.eventThreadTerminated == null)
                return;
            SystemEvents.eventThreadTerminated.Set();
        }

        private class SystemEventInvokeInfo
        {
            private SynchronizationContext _syncContext;
            private Delegate _delegate;

            public SystemEventInvokeInfo(Delegate d)
            {
                this._delegate = d;
                this._syncContext = AsyncOperationManager.SynchronizationContext;
            }

            public void Invoke(bool checkFinalization, params object[] args)
            {
                try
                {
                    if (this._syncContext == null || SystemEvents.UseEverettThreadAffinity)
                        this.InvokeCallback((object)args);
                    else
                        this._syncContext.Send(new SendOrPostCallback(this.InvokeCallback), (object)args);
                }
                catch (InvalidAsynchronousStateException ex)
                {
                    if (checkFinalization && AppDomain.CurrentDomain.IsFinalizingForUnload())
                        return;
                    this.InvokeCallback((object)args);
                }
            }

            private void InvokeCallback(object arg)
            {
                this._delegate.DynamicInvoke((object[])arg);
            }

            public override bool Equals(object other)
            {
                SystemEvents.SystemEventInvokeInfo systemEventInvokeInfo = other as SystemEvents.SystemEventInvokeInfo;
                if (systemEventInvokeInfo == null)
                    return false;
                return systemEventInvokeInfo._delegate.Equals((object)this._delegate);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}