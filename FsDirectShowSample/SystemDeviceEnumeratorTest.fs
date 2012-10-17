namespace FsDirectShowSample

open System
open System.Runtime.InteropServices
open System.Runtime.InteropServices.ComTypes
open FsDirectShow
open FsDirectShow.CoClassesHelper

module SystemDeviceEnumeratorTest =
    /// デバイスの取得
    let GetDevices fs filte =
        // システムデバイスの列挙体を作成？
        let devEnum = CreateDevEnum()

        let moniker = ref Unchecked.defaultof<IEnumMoniker>
        let hr =
            devEnum.CreateClassEnumerator(
                filte,
                moniker,
                CDef.None)
        DsError.ThrowExceptionForHR(hr)
        
        // 次のデバイスを取得し、シーケンスを関数に渡す。
        let getMoniker fs =
            let mon : IMoniker[] = Array.create 1 null
            if (!moniker).Next(1, mon, IntPtr.Zero) = 0 then
                try
                    use dev = new DsDevice(mon.[0])
                    fs dev
                    true
                finally
                    Marshal.ReleaseComObject(mon.[0]) |> ignore
            else
                false

        // すべてのデバイスを取得する。
        if hr = 0 && !moniker <> null then
            try
                Seq.initInfinite ((+)0)
                |> Seq.map (fun _ -> getMoniker fs)
                |> Seq.takeWhile id
                |> Seq.iter (fun _ -> ())
            finally
                Marshal.ReleaseComObject(!moniker) |> ignore

