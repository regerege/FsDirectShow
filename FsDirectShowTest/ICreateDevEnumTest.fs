namespace FsDirectShowTest
open MbUnit.Framework
open MbUnit.Framework.ContractVerifiers
open System
open System.Runtime.InteropServices
open System.Runtime.InteropServices.ComTypes
open FsDirectShow
open FsDirectShow.CoClassesHelper

(*
MbUnit Example
http://bugsquash.blogspot.jp/2012/05/f-dsl-for-mbunit.html
*)

[<TestFixture>]
type ICreateDevEnumTests() =
    [<Test>]
    member x.CreateCreateDevEnumTests() =
        let devEnum = CreateDevEnum()
        Assert.IsNotNull(devEnum)
        let moniker = ref Unchecked.defaultof<IEnumMoniker>
        let hr =
            devEnum.CreateClassEnumerator(
                FilterCategory.AudioRendererCategory,
                moniker,
                CDef.None)
        DsError.ThrowExceptionForHR(hr)

        // 次のデバイスの取得
        let getMoniker fs =
            let mon : IMoniker[] = Array.create 1 null
            if (!moniker).Next(1, mon, IntPtr.Zero) = 0 then
                try
                    use dev = new DsDevice(mon.[0])
                    fs dev
                    Assert.IsNotNull(dev)
                    true
                finally
                    Marshal.ReleaseComObject(mon.[0]) |> ignore
            else
                false

        // デバイスに対する処理
        let devtest (dev:DsDevice) =
            printfn "%A" dev.Name
            ()

        // すべてのデバイスを取得する。
        if hr = 0 && !moniker <> null then
            try
                Seq.initInfinite ((+)0)
                |> Seq.map (fun _ -> getMoniker devtest)
                |> Seq.takeWhile id
                |> Seq.iter (fun _ -> ())
            finally
                Marshal.ReleaseComObject(!moniker) |> ignore

        GC.Collect()

