namespace FsDirectShow

/// COMクラスのインスタンス生成ヘルパー
module CoClassesHelper =
    /// デバイスの列挙オブジェクトを生成
    let CreateDevEnum() =
        let obj = CoClasses.CreateInstance CoClasses.CreateDevEnum
        unbox<ICreateDevEnum>(obj)

