namespace FsDirectShow
open System
open System.Runtime.InteropServices
open System.Runtime.InteropServices.ComTypes
open System.Security

/// COMクラスのCLSIDをType型で取得するモジュール
module CoClasses =
    /// Typeのインスタンスを生成する。
    let CreateInstance (t:Type) = Activator.CreateInstance t
    /// デバイスの列挙クラス
    let CreateDevEnum = Type.GetTypeFromCLSID <| Guid "62BE5D10-60EB-11d0-BD3B-00A0C911CE86"

/// フィルターカテゴリ
module FilterCategory =
    /// CLSID_CPCAFiltersCategory
    let CPCAFiltersCategory = new Guid("C4C4C4FC-0049-4E2B-98FB-9537F6CE516D")
    /// CLSID_MediaEncoderCategory
    let MediaEncoderCategory = new Guid("7D22E920-5CA9-4787-8C2B-A6779BD11781")
    /// CLSID_MediaMultiplexerCategory
    let MediaMultiplexerCategory = new Guid("236C9559-ADCE-4736-BF72-BAB34E392196")
    /// CLSID_DMOFilterCategory
    let DMOFilterCategory = new Guid("bcd5796c-bd52-4d30-ab76-70f975b89199")
    /// CLSID_AudioInputDeviceCategory, audio capture category
    let AudioInputDevice = new Guid("33d9a762-90c8-11d0-bd43-00a0c911ce86")
    /// CLSID_VideoInputDeviceCategory, video capture category
    let VideoInputDevice = new Guid("860BB310-5D01-11d0-BD3B-00A0C911CE86")
    /// CLSID_VideoCompressorCategory, video compressor category
    let VideoCompressorCategory = new Guid("33d9a760-90c8-11d0-bd43-00a0c911ce86")
    /// CLSID_AudioCompressorCategory, audio compressor category
    let AudioCompressorCategory = new Guid("33d9a761-90c8-11d0-bd43-00a0c911ce86")
    /// CLSID_LegacyAmFilterCategory, legacy filters
    let LegacyAmFilterCategory = new Guid("083863F1-70DE-11d0-BD40-00A0C911CE86")
    /// CLSID_AudioRendererCategory, Audio renderer category</summary>
    let AudioRendererCategory = new Guid("e0f158e1-cb04-11d0-bd4e-00a0c911ce86")
    /// KSCATEGORY_BDA_RECEIVER_COMPONENT, BDA Receiver Components category</summary>
    let BDAReceiverComponentsCategory = new Guid("FD0A5AF4-B41D-11d2-9c95-00c04f7971e0")
    /// KSCATEGORY_BDA_NETWORK_TUNER, BDA Source Filters category</summary>
    let BDASourceFiltersCategory = new Guid("71985f48-1ca1-11d3-9cc8-00c04f7971e0")
    /// KSCATEGORY_BDA_IP_SINK, BDA Rendering Filters category</summary>
    let BDARenderingFiltersCategory = new Guid("71985f4a-1ca1-11d3-9cc8-00c04f7971e0")
    /// KSCATEGORY_BDA_NETWORK_PROVIDER, BDA Network Providers category</summary>
    let BDANetworkProvidersCategory = new Guid("71985f4b-1ca1-11d3-9cc8-00c04f7971e0")
    /// KSCATEGORY_BDA_TRANSPORT_INFORMATION, BDA Transport Information Renderers category</summary>
    let BDATransportInformationRenderersCategory = new Guid("a2e3074f-6c3d-11d3-b653-00c04f79498e")
    /// CLSID_MidiRendererCategory
    let MidiRendererCategory = new Guid("4EfE2452-168A-11d1-BC76-00c04FB9453B")
    /// CLSID_TransmitCategory  External Renderers Category</summary>
    let TransmitCategory = new Guid("cc7bfb41-f175-11d1-a392-00e0291f3959")
    /// CLSID_DeviceControlCategory  Device Control Filters</summary>
    let DeviceControlCategory = new Guid("cc7bfb46-f175-11d1-a392-00e0291f3959")
    /// CLSID_VideoEffects1Category
    let VideoEffects1Category = new Guid("cc7bfb42-f175-11d1-a392-00e0291f3959")
    /// CLSID_VideoEffects2Category
    let VideoEffects2Category = new Guid("cc7bfb43-f175-11d1-a392-00e0291f3959")
    /// CLSID_AudioEffects1Category
    let AudioEffects1Category = new Guid("cc7bfb44-f175-11d1-a392-00e0291f3959")
    /// CLSID_AudioEffects2Category
    let AudioEffects2Category = new Guid("cc7bfb45-f175-11d1-a392-00e0291f3959")
    /// KSCATEGORY_DATADECOMPRESSOR & CLSID_DVDHWDecodersCategory</summary>
    let KSDataDecompressor = new Guid("2721AE20-7E70-11D0-A5D6-28DB04C10000")
    /// KSCATEGORY_COMMUNICATIONSTRANSFORM
    let KSCommunicationsTransform = new Guid("CF1DDA2C-9743-11D0-A3EE-00A0C9223196")
    /// KSCATEGORY_DATATRANSFORM
    let KSDataTransform = new Guid("2EB07EA0-7E70-11D0-A5D6-28DB04C10000")
    /// KSCATEGORY_INTERFACETRANSFORM
    let KSInterfaceTransform = new Guid("CF1DDA2D-9743-11D0-A3EE-00A0C9223196")
    /// KSCATEGORY_MIXER
    let KSMixer = new Guid("AD809C00-7B88-11D0-A5D6-28DB04C10000")
    /// KSCATEGORY_AUDIO_DEVICE
    let KSAudioDevice = new Guid("FBF6F530-07B9-11D2-A71E-0000F8004788")
    /// CLSID_ActiveMovieCategories
    let ActiveMovieCategories = new Guid("da4e3da0-d07d-11d0-bd50-00a0c911ce86")
    /// AM_KSCATEGORY_CAPTURE
    let AMKSCapture = new Guid("65E8773D-8F56-11D0-A3B9-00A0C9223196")
    /// AM_KSCATEGORY_RENDER
    let AMKSRender = new Guid("65E8773E-8F56-11D0-A3B9-00A0C9223196")
    /// AM_KSCATEGORY_DATACOMPRESSOR
    let AMKSDataCompressor = new Guid("1E84C900-7E70-11D0-A5D6-28DB04C10000")
    /// AM_KSCATEGORY_AUDIO
    let AMKSAudio = new Guid("6994AD04-93EF-11D0-A3CC-00A0C9223196")
    /// AM_KSCATEGORY_VIDEO
    let AMKSVideo = new Guid("6994AD05-93EF-11D0-A3CC-00A0C9223196")
    /// AM_KSCATEGORY_TVTUNER
    let AMKSTVTuner = new Guid("a799a800-a46d-11d0-a18c-00a02401dcd4")
    /// AM_KSCATEGORY_CROSSBAR
    let AMKSCrossbar = new Guid("a799a801-a46d-11d0-a18c-00a02401dcd4")
    /// AM_KSCATEGORY_TVAUDIO
    let AMKSTVAudio = new Guid("a799a802-a46d-11d0-a18c-00a02401dcd4")
    /// AM_KSCATEGORY_VBICODEC
    let AMKSVBICodec = new Guid("07dad660-22f1-11d1-a9f4-00c04fbbde8f")
    /// AM_KSCATEGORY_SPLITTER
    let AMKSSplitter = new Guid("0A4252A0-7E70-11D0-A5D6-28DB04C10000")
    /// Not defined
    let WDMStreamingEncoderDevices = new Guid("19689BF6-C384-48FD-AD51-90E58C79F70B")
    /// Not defined
    let WDMStreamingMultiplexerDevices = new Guid("7A5DE1D3-01A1-452C-B481-4FA2B96271E8")
    /// Not defined
    let LTMMVideoProcessors = new Guid("E526D606-22E7-494C-B81E-AC0A94BFE603")
