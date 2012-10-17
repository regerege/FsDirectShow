namespace FsDirectShow
open System
open System.Runtime.InteropServices
open System.Runtime.InteropServices.ComTypes
open System.Security

///デバイスカテゴリ列挙体
[<Flags>]
type CDef =
    | None = 0
    | ClassDefault = 0x0001
    | BypassClassManager = 0x0002
    | ClassLegacy = 0x0004
    | MeritAboveDoNotUse = 0x0008
    /// オーディオまたはビデオ CODECを列挙する。
    | DevmonCMGRDevice = 0x0010
    /// DirectX Media Object (DMO)を列挙する。
    | DevmonDMO = 0x0020
    /// プラグアンドプレイ ハードウェア デバイスを列挙する。
    | DevmonPNPDevice = 0x0040
    /// DirectShow フィルタを列挙する。
    | DevmonFilter = 0x0080
    | DevmonSelectiveMask = 0x00F0

/// ビデオ キャプチャ デバイス、オーディオ キャプチャ デバイス、ビデオ コンプレッサなど、特定のカテゴリにあるデバイス用の列挙子を作成する。
[<ComImport; SuppressUnmanagedCodeSecurity;
Guid("29840822-5B84-11D0-BD3B-00A0C911CE86");
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>]
type ICreateDevEnum =
    /// <summary>指定されたデバイス カテゴリのクラス列挙子を作成する。</summary>
    /// <param name="pType">取得デバイスの種別</param>
    /// <param name="ppEnumMoniker">取得出来たデバイス</param>
    /// <param name="dwFlags">？？？</param>
    [<PreserveSig>]
    abstract CreateClassEnumerator :
        [<In; MarshalAs(UnmanagedType.LPStruct)>] pType : Guid *
        [<Out>] ppEnumMoniker : byref<IEnumMoniker> *
        [<In>] dwFlags : CDef
            -> int

