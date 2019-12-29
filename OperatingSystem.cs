﻿// Decompiled with JetBrains decompiler
// Type: OperatingSystem
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public static class OperatingSystem
{
  [DllImport("ntdll.dll", SetLastError = true)]
  private static extern OperatingSystem.NTSTATUS RtlGetVersion(
    ref OperatingSystem.OSVERSIONINFOEX versionInfo);

  private static OperatingSystem.OSVERSIONINFOEX GetVersion()
  {
    OperatingSystem.OSVERSIONINFOEX versionInfo = new OperatingSystem.OSVERSIONINFOEX()
    {
      OSVersionInfoSize = (uint) Marshal.SizeOf<OperatingSystem.OSVERSIONINFOEX>()
    };
    if (OperatingSystem.RtlGetVersion(ref versionInfo) != OperatingSystem.NTSTATUS.Success)
      throw new Win32Exception();
    return versionInfo;
  }

  public static string GetSystemVersionString()
  {
    try
    {
      return OperatingSystem.GetVersion().CSDVersion;
    }
    catch
    {
      return Environment.OSVersion.VersionString;
    }
  }

  public static Version GetSystemVersion()
  {
    try
    {
      OperatingSystem.OSVERSIONINFOEX version = OperatingSystem.GetVersion();
      return new Version((int) version.MajorVersion, (int) version.MinorVersion, (int) version.BuildNumber);
    }
    catch
    {
      return Environment.OSVersion.Version;
    }
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  private struct OSVERSIONINFOEX
  {
    internal uint OSVersionInfoSize;
    internal uint MajorVersion;
    internal uint MinorVersion;
    internal uint BuildNumber;
    internal uint PlatformId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    internal string CSDVersion;
    internal ushort ServicePackMajor;
    internal ushort ServicePackMinor;
    internal ushort SuiteMask;
    internal OperatingSystem.ProductType ProductType;
    internal byte Reserved;
  }

  private enum ProductType : byte
  {
    VER_NT_WORKSTATION = 1,
    VER_NT_DOMAIN_CONTROLLER = 2,
    VER_NT_SERVER = 3,
  }

  internal enum NTSTATUS : uint
  {
    Success = 0,
    Wait0 = 0,
    Wait1 = 1,
    Wait2 = 2,
    Wait3 = 3,
    Wait63 = 63, // 0x0000003F
    Abandoned = 128, // 0x00000080
    AbandonedWait0 = 128, // 0x00000080
    AbandonedWait1 = 129, // 0x00000081
    AbandonedWait2 = 130, // 0x00000082
    AbandonedWait3 = 131, // 0x00000083
    AbandonedWait63 = 191, // 0x000000BF
    UserApc = 192, // 0x000000C0
    KernelApc = 256, // 0x00000100
    Alerted = 257, // 0x00000101
    Timeout = 258, // 0x00000102
    Pending = 259, // 0x00000103
    Reparse = 260, // 0x00000104
    MoreEntries = 261, // 0x00000105
    NotAllAssigned = 262, // 0x00000106
    SomeNotMapped = 263, // 0x00000107
    OpLockBreakInProgress = 264, // 0x00000108
    VolumeMounted = 265, // 0x00000109
    RxActCommitted = 266, // 0x0000010A
    NotifyCleanup = 267, // 0x0000010B
    NotifyEnumDir = 268, // 0x0000010C
    NoQuotasForAccount = 269, // 0x0000010D
    PrimaryTransportConnectFailed = 270, // 0x0000010E
    PageFaultTransition = 272, // 0x00000110
    PageFaultDemandZero = 273, // 0x00000111
    PageFaultCopyOnWrite = 274, // 0x00000112
    PageFaultGuardPage = 275, // 0x00000113
    PageFaultPagingFile = 276, // 0x00000114
    CrashDump = 278, // 0x00000116
    ReparseObject = 280, // 0x00000118
    NothingToTerminate = 290, // 0x00000122
    ProcessNotInJob = 291, // 0x00000123
    ProcessInJob = 292, // 0x00000124
    ProcessCloned = 297, // 0x00000129
    FileLockedWithOnlyReaders = 298, // 0x0000012A
    FileLockedWithWriters = 299, // 0x0000012B
    Informational = 1073741824, // 0x40000000
    ObjectNameExists = 1073741824, // 0x40000000
    ThreadWasSuspended = 1073741825, // 0x40000001
    WorkingSetLimitRange = 1073741826, // 0x40000002
    ImageNotAtBase = 1073741827, // 0x40000003
    RegistryRecovered = 1073741833, // 0x40000009
    Warning = 2147483648, // 0x80000000
    GuardPageViolation = 2147483649, // 0x80000001
    DatatypeMisalignment = 2147483650, // 0x80000002
    Breakpoint = 2147483651, // 0x80000003
    SingleStep = 2147483652, // 0x80000004
    BufferOverflow = 2147483653, // 0x80000005
    NoMoreFiles = 2147483654, // 0x80000006
    HandlesClosed = 2147483658, // 0x8000000A
    PartialCopy = 2147483661, // 0x8000000D
    DeviceBusy = 2147483665, // 0x80000011
    InvalidEaName = 2147483667, // 0x80000013
    EaListInconsistent = 2147483668, // 0x80000014
    NoMoreEntries = 2147483674, // 0x8000001A
    LongJump = 2147483686, // 0x80000026
    DllMightBeInsecure = 2147483691, // 0x8000002B
    Error = 3221225472, // 0xC0000000
    Unsuccessful = 3221225473, // 0xC0000001
    NotImplemented = 3221225474, // 0xC0000002
    InvalidInfoClass = 3221225475, // 0xC0000003
    InfoLengthMismatch = 3221225476, // 0xC0000004
    AccessViolation = 3221225477, // 0xC0000005
    InPageError = 3221225478, // 0xC0000006
    PagefileQuota = 3221225479, // 0xC0000007
    InvalidHandle = 3221225480, // 0xC0000008
    BadInitialStack = 3221225481, // 0xC0000009
    BadInitialPc = 3221225482, // 0xC000000A
    InvalidCid = 3221225483, // 0xC000000B
    TimerNotCanceled = 3221225484, // 0xC000000C
    InvalidParameter = 3221225485, // 0xC000000D
    NoSuchDevice = 3221225486, // 0xC000000E
    NoSuchFile = 3221225487, // 0xC000000F
    InvalidDeviceRequest = 3221225488, // 0xC0000010
    EndOfFile = 3221225489, // 0xC0000011
    WrongVolume = 3221225490, // 0xC0000012
    NoMediaInDevice = 3221225491, // 0xC0000013
    NoMemory = 3221225495, // 0xC0000017
    NotMappedView = 3221225497, // 0xC0000019
    UnableToFreeVm = 3221225498, // 0xC000001A
    UnableToDeleteSection = 3221225499, // 0xC000001B
    IllegalInstruction = 3221225501, // 0xC000001D
    AlreadyCommitted = 3221225505, // 0xC0000021
    AccessDenied = 3221225506, // 0xC0000022
    BufferTooSmall = 3221225507, // 0xC0000023
    ObjectTypeMismatch = 3221225508, // 0xC0000024
    NonContinuableException = 3221225509, // 0xC0000025
    BadStack = 3221225512, // 0xC0000028
    NotLocked = 3221225514, // 0xC000002A
    NotCommitted = 3221225517, // 0xC000002D
    InvalidParameterMix = 3221225520, // 0xC0000030
    ObjectNameInvalid = 3221225523, // 0xC0000033
    ObjectNameNotFound = 3221225524, // 0xC0000034
    ObjectNameCollision = 3221225525, // 0xC0000035
    ObjectPathInvalid = 3221225529, // 0xC0000039
    ObjectPathNotFound = 3221225530, // 0xC000003A
    ObjectPathSyntaxBad = 3221225531, // 0xC000003B
    DataOverrun = 3221225532, // 0xC000003C
    DataLate = 3221225533, // 0xC000003D
    DataError = 3221225534, // 0xC000003E
    CrcError = 3221225535, // 0xC000003F
    SectionTooBig = 3221225536, // 0xC0000040
    PortConnectionRefused = 3221225537, // 0xC0000041
    InvalidPortHandle = 3221225538, // 0xC0000042
    SharingViolation = 3221225539, // 0xC0000043
    QuotaExceeded = 3221225540, // 0xC0000044
    InvalidPageProtection = 3221225541, // 0xC0000045
    MutantNotOwned = 3221225542, // 0xC0000046
    SemaphoreLimitExceeded = 3221225543, // 0xC0000047
    PortAlreadySet = 3221225544, // 0xC0000048
    SectionNotImage = 3221225545, // 0xC0000049
    SuspendCountExceeded = 3221225546, // 0xC000004A
    ThreadIsTerminating = 3221225547, // 0xC000004B
    BadWorkingSetLimit = 3221225548, // 0xC000004C
    IncompatibleFileMap = 3221225549, // 0xC000004D
    SectionProtection = 3221225550, // 0xC000004E
    EasNotSupported = 3221225551, // 0xC000004F
    EaTooLarge = 3221225552, // 0xC0000050
    NonExistentEaEntry = 3221225553, // 0xC0000051
    NoEasOnFile = 3221225554, // 0xC0000052
    EaCorruptError = 3221225555, // 0xC0000053
    FileLockConflict = 3221225556, // 0xC0000054
    LockNotGranted = 3221225557, // 0xC0000055
    DeletePending = 3221225558, // 0xC0000056
    CtlFileNotSupported = 3221225559, // 0xC0000057
    UnknownRevision = 3221225560, // 0xC0000058
    RevisionMismatch = 3221225561, // 0xC0000059
    InvalidOwner = 3221225562, // 0xC000005A
    InvalidPrimaryGroup = 3221225563, // 0xC000005B
    NoImpersonationToken = 3221225564, // 0xC000005C
    CantDisableMandatory = 3221225565, // 0xC000005D
    NoLogonServers = 3221225566, // 0xC000005E
    NoSuchLogonSession = 3221225567, // 0xC000005F
    NoSuchPrivilege = 3221225568, // 0xC0000060
    PrivilegeNotHeld = 3221225569, // 0xC0000061
    InvalidAccountName = 3221225570, // 0xC0000062
    UserExists = 3221225571, // 0xC0000063
    NoSuchUser = 3221225572, // 0xC0000064
    GroupExists = 3221225573, // 0xC0000065
    NoSuchGroup = 3221225574, // 0xC0000066
    MemberInGroup = 3221225575, // 0xC0000067
    MemberNotInGroup = 3221225576, // 0xC0000068
    LastAdmin = 3221225577, // 0xC0000069
    WrongPassword = 3221225578, // 0xC000006A
    IllFormedPassword = 3221225579, // 0xC000006B
    PasswordRestriction = 3221225580, // 0xC000006C
    LogonFailure = 3221225581, // 0xC000006D
    AccountRestriction = 3221225582, // 0xC000006E
    InvalidLogonHours = 3221225583, // 0xC000006F
    InvalidWorkstation = 3221225584, // 0xC0000070
    PasswordExpired = 3221225585, // 0xC0000071
    AccountDisabled = 3221225586, // 0xC0000072
    NoneMapped = 3221225587, // 0xC0000073
    TooManyLuidsRequested = 3221225588, // 0xC0000074
    LuidsExhausted = 3221225589, // 0xC0000075
    InvalidSubAuthority = 3221225590, // 0xC0000076
    InvalidAcl = 3221225591, // 0xC0000077
    InvalidSid = 3221225592, // 0xC0000078
    InvalidSecurityDescr = 3221225593, // 0xC0000079
    ProcedureNotFound = 3221225594, // 0xC000007A
    InvalidImageFormat = 3221225595, // 0xC000007B
    NoToken = 3221225596, // 0xC000007C
    BadInheritanceAcl = 3221225597, // 0xC000007D
    RangeNotLocked = 3221225598, // 0xC000007E
    DiskFull = 3221225599, // 0xC000007F
    ServerDisabled = 3221225600, // 0xC0000080
    ServerNotDisabled = 3221225601, // 0xC0000081
    TooManyGuidsRequested = 3221225602, // 0xC0000082
    GuidsExhausted = 3221225603, // 0xC0000083
    InvalidIdAuthority = 3221225604, // 0xC0000084
    AgentsExhausted = 3221225605, // 0xC0000085
    InvalidVolumeLabel = 3221225606, // 0xC0000086
    SectionNotExtended = 3221225607, // 0xC0000087
    NotMappedData = 3221225608, // 0xC0000088
    ResourceDataNotFound = 3221225609, // 0xC0000089
    ResourceTypeNotFound = 3221225610, // 0xC000008A
    ResourceNameNotFound = 3221225611, // 0xC000008B
    ArrayBoundsExceeded = 3221225612, // 0xC000008C
    FloatDenormalOperand = 3221225613, // 0xC000008D
    FloatDivideByZero = 3221225614, // 0xC000008E
    FloatInexactResult = 3221225615, // 0xC000008F
    FloatInvalidOperation = 3221225616, // 0xC0000090
    FloatOverflow = 3221225617, // 0xC0000091
    FloatStackCheck = 3221225618, // 0xC0000092
    FloatUnderflow = 3221225619, // 0xC0000093
    IntegerDivideByZero = 3221225620, // 0xC0000094
    IntegerOverflow = 3221225621, // 0xC0000095
    PrivilegedInstruction = 3221225622, // 0xC0000096
    TooManyPagingFiles = 3221225623, // 0xC0000097
    FileInvalid = 3221225624, // 0xC0000098
    InstanceNotAvailable = 3221225643, // 0xC00000AB
    PipeNotAvailable = 3221225644, // 0xC00000AC
    InvalidPipeState = 3221225645, // 0xC00000AD
    PipeBusy = 3221225646, // 0xC00000AE
    IllegalFunction = 3221225647, // 0xC00000AF
    PipeDisconnected = 3221225648, // 0xC00000B0
    PipeClosing = 3221225649, // 0xC00000B1
    PipeConnected = 3221225650, // 0xC00000B2
    PipeListening = 3221225651, // 0xC00000B3
    InvalidReadMode = 3221225652, // 0xC00000B4
    IoTimeout = 3221225653, // 0xC00000B5
    FileForcedClosed = 3221225654, // 0xC00000B6
    ProfilingNotStarted = 3221225655, // 0xC00000B7
    ProfilingNotStopped = 3221225656, // 0xC00000B8
    NotSameDevice = 3221225684, // 0xC00000D4
    FileRenamed = 3221225685, // 0xC00000D5
    CantWait = 3221225688, // 0xC00000D8
    PipeEmpty = 3221225689, // 0xC00000D9
    CantTerminateSelf = 3221225691, // 0xC00000DB
    InternalError = 3221225701, // 0xC00000E5
    InvalidParameter1 = 3221225711, // 0xC00000EF
    InvalidParameter2 = 3221225712, // 0xC00000F0
    InvalidParameter3 = 3221225713, // 0xC00000F1
    InvalidParameter4 = 3221225714, // 0xC00000F2
    InvalidParameter5 = 3221225715, // 0xC00000F3
    InvalidParameter6 = 3221225716, // 0xC00000F4
    InvalidParameter7 = 3221225717, // 0xC00000F5
    InvalidParameter8 = 3221225718, // 0xC00000F6
    InvalidParameter9 = 3221225719, // 0xC00000F7
    InvalidParameter10 = 3221225720, // 0xC00000F8
    InvalidParameter11 = 3221225721, // 0xC00000F9
    InvalidParameter12 = 3221225722, // 0xC00000FA
    MappedFileSizeZero = 3221225758, // 0xC000011E
    TooManyOpenedFiles = 3221225759, // 0xC000011F
    Cancelled = 3221225760, // 0xC0000120
    CannotDelete = 3221225761, // 0xC0000121
    InvalidComputerName = 3221225762, // 0xC0000122
    FileDeleted = 3221225763, // 0xC0000123
    SpecialAccount = 3221225764, // 0xC0000124
    SpecialGroup = 3221225765, // 0xC0000125
    SpecialUser = 3221225766, // 0xC0000126
    MembersPrimaryGroup = 3221225767, // 0xC0000127
    FileClosed = 3221225768, // 0xC0000128
    TooManyThreads = 3221225769, // 0xC0000129
    ThreadNotInProcess = 3221225770, // 0xC000012A
    TokenAlreadyInUse = 3221225771, // 0xC000012B
    PagefileQuotaExceeded = 3221225772, // 0xC000012C
    CommitmentLimit = 3221225773, // 0xC000012D
    InvalidImageLeFormat = 3221225774, // 0xC000012E
    InvalidImageNotMz = 3221225775, // 0xC000012F
    InvalidImageProtect = 3221225776, // 0xC0000130
    InvalidImageWin16 = 3221225777, // 0xC0000131
    LogonServer = 3221225778, // 0xC0000132
    DifferenceAtDc = 3221225779, // 0xC0000133
    SynchronizationRequired = 3221225780, // 0xC0000134
    DllNotFound = 3221225781, // 0xC0000135
    IoPrivilegeFailed = 3221225783, // 0xC0000137
    OrdinalNotFound = 3221225784, // 0xC0000138
    EntryPointNotFound = 3221225785, // 0xC0000139
    ControlCExit = 3221225786, // 0xC000013A
    PortNotSet = 3221226323, // 0xC0000353
    DebuggerInactive = 3221226324, // 0xC0000354
    CallbackBypass = 3221226755, // 0xC0000503
    PortClosed = 3221227264, // 0xC0000700
    MessageLost = 3221227265, // 0xC0000701
    InvalidMessage = 3221227266, // 0xC0000702
    RequestCanceled = 3221227267, // 0xC0000703
    RecursiveDispatch = 3221227268, // 0xC0000704
    LpcReceiveBufferExpected = 3221227269, // 0xC0000705
    LpcInvalidConnectionUsage = 3221227270, // 0xC0000706
    LpcRequestsNotAllowed = 3221227271, // 0xC0000707
    ResourceInUse = 3221227272, // 0xC0000708
    ProcessIsProtected = 3221227282, // 0xC0000712
    VolumeDirty = 3221227526, // 0xC0000806
    FileCheckedOut = 3221227777, // 0xC0000901
    CheckOutRequired = 3221227778, // 0xC0000902
    BadFileType = 3221227779, // 0xC0000903
    FileTooLarge = 3221227780, // 0xC0000904
    FormsAuthRequired = 3221227781, // 0xC0000905
    VirusInfected = 3221227782, // 0xC0000906
    VirusDeleted = 3221227783, // 0xC0000907
    TransactionalConflict = 3222863873, // 0xC0190001
    InvalidTransaction = 3222863874, // 0xC0190002
    TransactionNotActive = 3222863875, // 0xC0190003
    TmInitializationFailed = 3222863876, // 0xC0190004
    RmNotActive = 3222863877, // 0xC0190005
    RmMetadataCorrupt = 3222863878, // 0xC0190006
    TransactionNotJoined = 3222863879, // 0xC0190007
    DirectoryNotRm = 3222863880, // 0xC0190008
    CouldNotResizeLog = 3222863881, // 0xC0190009
    TransactionsUnsupportedRemote = 3222863882, // 0xC019000A
    LogResizeInvalidSize = 3222863883, // 0xC019000B
    RemoteFileVersionMismatch = 3222863884, // 0xC019000C
    CrmProtocolAlreadyExists = 3222863887, // 0xC019000F
    TransactionPropagationFailed = 3222863888, // 0xC0190010
    CrmProtocolNotFound = 3222863889, // 0xC0190011
    TransactionSuperiorExists = 3222863890, // 0xC0190012
    TransactionRequestNotValid = 3222863891, // 0xC0190013
    TransactionNotRequested = 3222863892, // 0xC0190014
    TransactionAlreadyAborted = 3222863893, // 0xC0190015
    TransactionAlreadyCommitted = 3222863894, // 0xC0190016
    TransactionInvalidMarshallBuffer = 3222863895, // 0xC0190017
    CurrentTransactionNotValid = 3222863896, // 0xC0190018
    LogGrowthFailed = 3222863897, // 0xC0190019
    ObjectNoLongerExists = 3222863905, // 0xC0190021
    StreamMiniversionNotFound = 3222863906, // 0xC0190022
    StreamMiniversionNotValid = 3222863907, // 0xC0190023
    MiniversionInaccessibleFromSpecifiedTransaction = 3222863908, // 0xC0190024
    CantOpenMiniversionWithModifyIntent = 3222863909, // 0xC0190025
    CantCreateMoreStreamMiniversions = 3222863910, // 0xC0190026
    HandleNoLongerValid = 3222863912, // 0xC0190028
    NoTxfMetadata = 3222863913, // 0xC0190029
    LogCorruptionDetected = 3222863920, // 0xC0190030
    CantRecoverWithHandleOpen = 3222863921, // 0xC0190031
    RmDisconnected = 3222863922, // 0xC0190032
    EnlistmentNotSuperior = 3222863923, // 0xC0190033
    RecoveryNotNeeded = 3222863924, // 0xC0190034
    RmAlreadyStarted = 3222863925, // 0xC0190035
    FileIdentityNotPersistent = 3222863926, // 0xC0190036
    CantBreakTransactionalDependency = 3222863927, // 0xC0190037
    CantCrossRmBoundary = 3222863928, // 0xC0190038
    TxfDirNotEmpty = 3222863929, // 0xC0190039
    IndoubtTransactionsExist = 3222863930, // 0xC019003A
    TmVolatile = 3222863931, // 0xC019003B
    RollbackTimerExpired = 3222863932, // 0xC019003C
    TxfAttributeCorrupt = 3222863933, // 0xC019003D
    EfsNotAllowedInTransaction = 3222863934, // 0xC019003E
    TransactionalOpenNotAllowed = 3222863935, // 0xC019003F
    TransactedMappingUnsupportedRemote = 3222863936, // 0xC0190040
    TxfMetadataAlreadyPresent = 3222863937, // 0xC0190041
    TransactionScopeCallbacksNotSet = 3222863938, // 0xC0190042
    TransactionRequiredPromotion = 3222863939, // 0xC0190043
    CannotExecuteFileInTransaction = 3222863940, // 0xC0190044
    TransactionsNotFrozen = 3222863941, // 0xC0190045
    MaximumNtStatus = 4294967295, // 0xFFFFFFFF
  }
}
