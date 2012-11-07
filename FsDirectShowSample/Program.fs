open FsDirectShow
open FsDirectShow.CoClassesHelper
open FsDirectShowSample.SystemDeviceEnumeratorTest


let cats =
    [
        "ActiveMovieCategories"                           ,FilterCategory.ActiveMovieCategories
        "AMKSAudio"                                       ,FilterCategory.AMKSAudio
        "AMKSCapture"                                     ,FilterCategory.AMKSCapture
        "AMKSCrossbar"                                    ,FilterCategory.AMKSCrossbar
        "AMKSDataCompressor"                              ,FilterCategory.AMKSDataCompressor
        "AMKSRender"                                      ,FilterCategory.AMKSRender
        "AMKSSplitter"                                    ,FilterCategory.AMKSSplitter
        "AMKSTVAudio"                                     ,FilterCategory.AMKSTVAudio
        "AMKSTVTuner"                                     ,FilterCategory.AMKSTVTuner
        "AMKSVBICodec"                                    ,FilterCategory.AMKSVBICodec
        "AMKSVideo"                                       ,FilterCategory.AMKSVideo
        "AudioCompressorCategory"                         ,FilterCategory.AudioCompressorCategory
        "AudioEffects1Category"                           ,FilterCategory.AudioEffects1Category
        "AudioEffects2Category"                           ,FilterCategory.AudioEffects2Category
        "AudioInputDevice"                                ,FilterCategory.AudioInputDevice
        "AudioRendererCategory"                           ,FilterCategory.AudioRendererCategory
        "BDANetworkProvidersCategory"                     ,FilterCategory.BDANetworkProvidersCategory
        "BDAReceiverComponentsCategory"                   ,FilterCategory.BDAReceiverComponentsCategory
        "BDARenderingFiltersCategory"                     ,FilterCategory.BDARenderingFiltersCategory
        "BDASourceFiltersCategory"                        ,FilterCategory.BDASourceFiltersCategory
        "BDATransportInformationRenderersCategory"        ,FilterCategory.BDATransportInformationRenderersCategory
        "CPCAFiltersCategory"                             ,FilterCategory.CPCAFiltersCategory
        "DeviceControlCategory"                           ,FilterCategory.DeviceControlCategory
        "DMOFilterCategory"                               ,FilterCategory.DMOFilterCategory
        "KSAudioDevice"                                   ,FilterCategory.KSAudioDevice
        "KSCommunicationsTransform"                       ,FilterCategory.KSCommunicationsTransform
        "KSDataDecompressor"                              ,FilterCategory.KSDataDecompressor
        "KSDataTransform"                                 ,FilterCategory.KSDataTransform
        "KSInterfaceTransform"                            ,FilterCategory.KSInterfaceTransform
        "KSMixer"                                         ,FilterCategory.KSMixer
        "LegacyAmFilterCategory"                          ,FilterCategory.LegacyAmFilterCategory
        "LTMMVideoProcessors"                             ,FilterCategory.LTMMVideoProcessors
        "MediaEncoderCategory"                            ,FilterCategory.MediaEncoderCategory
        "MediaMultiplexerCategory"                        ,FilterCategory.MediaMultiplexerCategory
        "MidiRendererCategory"                            ,FilterCategory.MidiRendererCategory
        "TransmitCategory"                                ,FilterCategory.TransmitCategory
        "VideoCompressorCategory"                         ,FilterCategory.VideoCompressorCategory
        "VideoEffects1Category"                           ,FilterCategory.VideoEffects1Category
        "VideoEffects2Category"                           ,FilterCategory.VideoEffects2Category
        "VideoInputDevice"                                ,FilterCategory.VideoInputDevice
        "WDMStreamingEncoderDevices"                      ,FilterCategory.WDMStreamingEncoderDevices
        "WDMStreamingMultiplexerDevices"                  ,FilterCategory.WDMStreamingMultiplexerDevices
    ]

open System
open System.Diagnostics

Trace.Listeners.Add(new ConsoleTraceListener()) |> ignore

let setIndent v =
    Trace.IndentLevel <- v
let trace (s:string) =
    Trace.WriteLine(s)

cats
|> Seq.iter (fun (n,c) ->
    setIndent 0
    trace <| sprintf "%A" (new System.String('=', 50))
    trace <| sprintf "Get '%A' Devices" n
    c |> GetDevices (fun dev ->
        setIndent 1
        trace <| sprintf "%A" (new System.String('-', 50))
//        trace <| sprintf "ClassID: %A" dev.ClassID
//        trace <| sprintf "DevicePath: %A" dev.DevicePath
//        trace <| sprintf "Mon: %A" dev.Moniker
        trace <| sprintf "Name: %A" dev.Name
        trace <| sprintf ""
        ))
