namespace NoriScheduler.Services;

/// <summary>
/// 存放一些全局的配置
/// </summary>
internal static class NoriScheduleConfiguration
{
    /// <summary>
    /// 输出的txt文件位置
    /// </summary>
    public static string TextOutputPath = Path.Combine(Environment.CurrentDirectory,
        DateTime.Now.ToShortDateString().Replace('/', '-')
        + ".txt");
    /// <summary>
    /// 输出的markdown文件位置
    /// </summary>
    public static string MarkdownOutputPath = Path.Combine(Environment.CurrentDirectory,
        DateTime.Now.ToShortDateString().Replace('/', '-')
        + ".md");

    /// <summary>
    /// 输出pdf文件的文件路径
    /// </summary>
    public static string PdfOutputPath = Path.Combine(Environment.CurrentDirectory,
        DateTime.Now.ToShortDateString().Replace('/', '-')
        + ".pdf");

    /// <summary>
    /// 用于检索是否为视频投稿的关键词字典
    /// </summary>
    public static string[] VideoUploadKeys = new[]
    {
        "covered",
        "video",
    };

    /// <summary>
    /// 用于检索是否为合作直播
    /// </summary>
    public static string[] CoopKeys = new[]
    {
        "くまたま"
    };
}