// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SYSTEM_INFORMATION_CLASS.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum SYSTEM_INFORMATION_CLASS
    /// </summary>
    public enum SYSTEM_INFORMATION_CLASS
    {
        /// <summary>
        /// The system information class minimum
        /// </summary>
        SystemInformationClassMin = 0,
        /// <summary>
        /// The system basic information
        /// </summary>
        SystemBasicInformation = 0,
        /// <summary>
        /// The system processor information
        /// </summary>
        SystemProcessorInformation = 1,
        /// <summary>
        /// The system performance information
        /// </summary>
        SystemPerformanceInformation = 2,
        /// <summary>
        /// The system time of day information
        /// </summary>
        SystemTimeOfDayInformation = 3,
        /// <summary>
        /// The system path information
        /// </summary>
        SystemPathInformation = 4,
        /// <summary>
        /// The system not implemented1
        /// </summary>
        SystemNotImplemented1 = 4,
        /// <summary>
        /// The system process information
        /// </summary>
        SystemProcessInformation = 5,
        /// <summary>
        /// The system processes and threads information
        /// </summary>
        SystemProcessesAndThreadsInformation = 5,
        /// <summary>
        /// The system call count information information
        /// </summary>
        SystemCallCountInfoInformation = 6,
        /// <summary>
        /// The system call counts
        /// </summary>
        SystemCallCounts = 6,
        /// <summary>
        /// The system device information
        /// </summary>
        SystemDeviceInformation = 7,
        /// <summary>
        /// The system configuration information
        /// </summary>
        SystemConfigurationInformation = 7,
        /// <summary>
        /// The system processor performance information
        /// </summary>
        SystemProcessorPerformanceInformation = 8,
        /// <summary>
        /// The system processor times
        /// </summary>
        SystemProcessorTimes = 8,
        /// <summary>
        /// The system flags information
        /// </summary>
        SystemFlagsInformation = 9,
        /// <summary>
        /// The system global flag
        /// </summary>
        SystemGlobalFlag = 9,
        /// <summary>
        /// The system call time information
        /// </summary>
        SystemCallTimeInformation = 10,
        /// <summary>
        /// The system not implemented2
        /// </summary>
        SystemNotImplemented2 = 10,
        /// <summary>
        /// The system module information
        /// </summary>
        SystemModuleInformation = 11,
        /// <summary>
        /// The system locks information
        /// </summary>
        SystemLocksInformation = 12,
        /// <summary>
        /// The system lock information
        /// </summary>
        SystemLockInformation = 12,
        /// <summary>
        /// The system stack trace information
        /// </summary>
        SystemStackTraceInformation = 13,
        /// <summary>
        /// The system not implemented3
        /// </summary>
        SystemNotImplemented3 = 13,
        /// <summary>
        /// The system paged pool information
        /// </summary>
        SystemPagedPoolInformation = 14,
        /// <summary>
        /// The system not implemented4
        /// </summary>
        SystemNotImplemented4 = 14,
        /// <summary>
        /// The system non paged pool information
        /// </summary>
        SystemNonPagedPoolInformation = 15,
        /// <summary>
        /// The system not implemented5
        /// </summary>
        SystemNotImplemented5 = 15,
        /// <summary>
        /// The system handle information
        /// </summary>
        SystemHandleInformation = 16,
        /// <summary>
        /// The system object information
        /// </summary>
        SystemObjectInformation = 17,
        /// <summary>
        /// The system page file information
        /// </summary>
        SystemPageFileInformation = 18,
        /// <summary>
        /// The system pagefile information
        /// </summary>
        SystemPagefileInformation = 18,
        /// <summary>
        /// The system VDM instemul information
        /// </summary>
        SystemVdmInstemulInformation = 19,
        /// <summary>
        /// The system instruction emulation counts
        /// </summary>
        SystemInstructionEmulationCounts = 19,
        /// <summary>
        /// The system VDM bop information
        /// </summary>
        SystemVdmBopInformation = 20,
        /// <summary>
        /// The system invalid information class1
        /// </summary>
        SystemInvalidInfoClass1 = 20,
        /// <summary>
        /// The system file cache information
        /// </summary>
        SystemFileCacheInformation = 21,
        /// <summary>
        /// The system cache information
        /// </summary>
        SystemCacheInformation = 21,
        /// <summary>
        /// The system pool tag information
        /// </summary>
        SystemPoolTagInformation = 22,
        /// <summary>
        /// The system interrupt information
        /// </summary>
        SystemInterruptInformation = 23,
        /// <summary>
        /// The system processor statistics
        /// </summary>
        SystemProcessorStatistics = 23,
        /// <summary>
        /// The system DPC behaviour information
        /// </summary>
        SystemDpcBehaviourInformation = 24,
        /// <summary>
        /// The system DPC information
        /// </summary>
        SystemDpcInformation = 24,
        /// <summary>
        /// The system full memory information
        /// </summary>
        SystemFullMemoryInformation = 25,
        /// <summary>
        /// The system not implemented6
        /// </summary>
        SystemNotImplemented6 = 25,
        /// <summary>
        /// The system load image
        /// </summary>
        SystemLoadImage = 26,
        /// <summary>
        /// The system unload image
        /// </summary>
        SystemUnloadImage = 27,
        /// <summary>
        /// The system time adjustment information
        /// </summary>
        SystemTimeAdjustmentInformation = 28,
        /// <summary>
        /// The system time adjustment
        /// </summary>
        SystemTimeAdjustment = 28,
        /// <summary>
        /// The system summary memory information
        /// </summary>
        SystemSummaryMemoryInformation = 29,
        /// <summary>
        /// The system not implemented7
        /// </summary>
        SystemNotImplemented7 = 29,
        /// <summary>
        /// The system next event identifier information
        /// </summary>
        SystemNextEventIdInformation = 30,
        /// <summary>
        /// The system not implemented8
        /// </summary>
        SystemNotImplemented8 = 30,
        /// <summary>
        /// The system event ids information
        /// </summary>
        SystemEventIdsInformation = 31,
        /// <summary>
        /// The system not implemented9
        /// </summary>
        SystemNotImplemented9 = 31,
        /// <summary>
        /// The system crash dump information
        /// </summary>
        SystemCrashDumpInformation = 32,
        /// <summary>
        /// The system exception information
        /// </summary>
        SystemExceptionInformation = 33,
        /// <summary>
        /// The system crash dump state information
        /// </summary>
        SystemCrashDumpStateInformation = 34,
        /// <summary>
        /// The system kernel debugger information
        /// </summary>
        SystemKernelDebuggerInformation = 35,
        /// <summary>
        /// The system context switch information
        /// </summary>
        SystemContextSwitchInformation = 36,
        /// <summary>
        /// The system registry quota information
        /// </summary>
        SystemRegistryQuotaInformation = 37,
        /// <summary>
        /// The system load and call image
        /// </summary>
        SystemLoadAndCallImage = 38,
        /// <summary>
        /// The system priority separation
        /// </summary>
        SystemPrioritySeparation = 39,
        /// <summary>
        /// The system plug play bus information
        /// </summary>
        SystemPlugPlayBusInformation = 40,
        /// <summary>
        /// The system not implemented10
        /// </summary>
        SystemNotImplemented10 = 40,
        /// <summary>
        /// The system dock information
        /// </summary>
        SystemDockInformation = 41,
        /// <summary>
        /// The system not implemented11
        /// </summary>
        SystemNotImplemented11 = 41,
        /// <summary>
        /// The system invalid information class2
        /// </summary>
        SystemInvalidInfoClass2 = 42,
        /// <summary>
        /// The system processor speed information
        /// </summary>
        SystemProcessorSpeedInformation = 43,
        /// <summary>
        /// The system invalid information class3
        /// </summary>
        SystemInvalidInfoClass3 = 43,
        /// <summary>
        /// The system current time zone information
        /// </summary>
        SystemCurrentTimeZoneInformation = 44,
        /// <summary>
        /// The system time zone information
        /// </summary>
        SystemTimeZoneInformation = 44,
        /// <summary>
        /// The system lookaside information
        /// </summary>
        SystemLookasideInformation = 45,
        /// <summary>
        /// The system set time slip event
        /// </summary>
        SystemSetTimeSlipEvent = 46,
        /// <summary>
        /// The system create session
        /// </summary>
        SystemCreateSession = 47,
        /// <summary>
        /// The system delete session
        /// </summary>
        SystemDeleteSession = 48,
        /// <summary>
        /// The system invalid information class4
        /// </summary>
        SystemInvalidInfoClass4 = 49,
        /// <summary>
        /// The system range start information
        /// </summary>
        SystemRangeStartInformation = 50,
        /// <summary>
        /// The system verifier information
        /// </summary>
        SystemVerifierInformation = 51,
        /// <summary>
        /// The system add verifier
        /// </summary>
        SystemAddVerifier = 52,
        /// <summary>
        /// The system session processes information
        /// </summary>
        SystemSessionProcessesInformation = 53,
        /// <summary>
        /// The system information class maximum
        /// </summary>
        SystemInformationClassMax
    }
}
