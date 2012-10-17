namespace DirectShowLib

open System
open System.Reflection
open System.Runtime.InteropServices
//open System.Security.Permissions

// アセンブリの署名
[<assembly: AssemblyKeyFile("FsDirectShow.snk")>]
//[<assembly : AssemblyKeyName("")>]

// アセンブリ情報
[<assembly: AssemblyTitle("FsDirectShow")>]
[<assembly: AssemblyDescription("DirectShow for FSharp")>]
[<assembly: AssemblyConfiguration("")>]
[<assembly: AssemblyCompany("")>]
#if DEBUG
[<assembly: AssemblyProduct("FsDirectShow-Debug")>]
#else
[<assembly: AssemblyProduct("FsDirectShow")>]
#endif
[<assembly: AssemblyCopyright("GNU Lesser General Public License v2.1")>]
[<assembly: AssemblyTrademark("")>]
//[<assembly: AssemblyCulture("")>]

[<assembly: ComVisible(false)>]
[<assembly: CLSCompliant(true)>]

[<assembly: Guid("4E8918C7-B4E4-4900-8B45-54C19D26E206")>]

[<assembly: AssemblyVersion("0.0.1.*")>]
[<assembly: AssemblyFileVersion("0.0.1.*")>]
()
