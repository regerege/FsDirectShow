namespace FsDirectShowTest
open MbUnit.Framework
open MbUnit.Framework.ContractVerifiers
open System
open FsDirectShow
open FsDirectShow.CoClassesHelper

[<TestFixtureAttribute>]
type ICreateDevEnumTests() =
    [<Test>]
    member x.CreateCreateDevEnumTests() =
        let ic = CreateDevEnum()
        Assert.IsNotNull(ic)
        GC.Collect()

