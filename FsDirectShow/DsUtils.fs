namespace FsDirectShow
open System
open System.Runtime.InteropServices
open System.Runtime.InteropServices.ComTypes
open System.Security
open System.Text

module DsError =
    [<DllImport("quartz.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "AMGetErrorTextW");
    SuppressUnmanagedCodeSecurity>]
    extern int AMGetErrorText(int hr, StringBuilder buf, int max)

    let GetErrorText (hr:int) =
        let MAX_ERROR_TEXT_LEN = 160
        let buf = new StringBuilder(MAX_ERROR_TEXT_LEN, MAX_ERROR_TEXT_LEN)
        if 0 < AMGetErrorText(hr, buf, MAX_ERROR_TEXT_LEN) then
            buf.ToString()
        else Unchecked.defaultof<string>

    let ThrowExceptionForHR (hr:int) =
        if hr < 0 then
            let s = GetErrorText(hr)
            if s <> null then raise <| new COMException(s, hr)
            else Marshal.ThrowExceptionForHR(hr)

type DsDevice(moniker:IMoniker) =
    let GetPropBagValue (name:string) =
        if moniker <> null then
            let bagId = ref typeof<IPropertyBag>.GUID
            let bagObj = moniker.BindToStorage(null, null, bagId)
            try
                let bag = unbox<IPropertyBag>(bagObj)
                let  v = ref null
                let hr = bag.Read(name, v, IntPtr.Zero)
                DsError.ThrowExceptionForHR hr
                match !v with
                | :? string as s -> s
                | _ -> null
            finally
                if bagObj <> null then
                    Marshal.ReleaseComObject(bagObj) |> ignore
        else null
    let _name = GetPropBagValue("FriendlyName")

    /// デバイス名を取得する。
    member x.Name = _name
    /// モニカーを取得する。
    member x.Moniker = moniker
    /// デバイスIDを取得する。
    member x.DevicePath =
        try
            let s = moniker.GetDisplayName(null,null)
            s
        with
        | _ -> ""
    /// デバイスのClassIDを取得する。
    member x.ClassID =
        if moniker <> null then
            let g = moniker.GetClassID() in g
        else Guid.Empty

    /// モニカーを解放する。
    member x.Dispose() =
        if moniker <> null then
            Marshal.ReleaseComObject(moniker) |> ignore
    interface IDisposable with
        member x.Dispose() = x.Dispose()
