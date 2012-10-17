namespace FsDirectShow
open System
open System.Runtime.InteropServices
//open System.Runtime.InteropServices.ComTypes
open System.Security
//open System.Text

[<ComImport; SuppressUnmanagedCodeSecurity;
Guid("3127CA40-446E-11CE-8135-00AA004BB851")
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>]
type IErrorLog =
    [<PreserveSig>]
    abstract AddError :
        [<In; MarshalAs(UnmanagedType.LPWStr)>] pszPropName : string *
        [<In>] pExcepInfo : ComTypes.EXCEPINFO
            -> int

[<ComImport; SuppressUnmanagedCodeSecurity;
Guid("55272A00-42CB-11CE-8135-00AA004BB851");
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>]
type IPropertyBag =
    [<PreserveSig>]
    abstract Read :
        [<In; MarshalAs(UnmanagedType.LPWStr)>] pszPropName : string *
        [<In; Out; MarshalAs(UnmanagedType.Struct)>] pVar : byref<obj> *
//        [<In>] pErrorLog : IErrorLog
        [<In>] pErrorLog : IntPtr
            -> int
    [<PreserveSig>]
    abstract Write :
        [<In; MarshalAs(UnmanagedType.LPWStr)>] pszPropName : string *
        [<In; MarshalAs(UnmanagedType.Struct)>] pVar : byref<obj>
            -> int

