namespace FsDirectShowSample

open System
open System.Reflection
open System.Runtime.InteropServices

//// アセンブリの署名
//[<assembly: AssemblyKeyFile("FsDirectShowSample.snk")>]

// アセンブリ情報
[<assembly: AssemblyTitle("FsDirectShowSample")>]
[<assembly: AssemblyDescription("DirectShow for FSharp")>]
[<assembly: AssemblyConfiguration("")>]
[<assembly: AssemblyCompany("")>]
#if DEBUG
[<assembly: AssemblyProduct("FsDirectShowSample-Debug")>]
#else
[<assembly: AssemblyProduct("FsDirectShowSample")>]
#endif
[<assembly: AssemblyCopyright("GNU Lesser General Public License v2.1")>]
[<assembly: AssemblyTrademark("")>]
//[<assembly: AssemblyCulture("")>]

[<assembly: ComVisible(false)>]
[<assembly: CLSCompliant(true)>]

[<assembly: Guid("468E9D7A-CFC8-41AA-98ED-B867E872083E")>]

[<assembly: AssemblyVersion("0.0.1.*")>]
[<assembly: AssemblyFileVersion("0.0.1.*")>]
()
