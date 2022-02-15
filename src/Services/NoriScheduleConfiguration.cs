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

}