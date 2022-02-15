using System.Runtime.InteropServices;

namespace NoriScheduler.Services;

/// <summary>
/// 用来开启外部文档编辑器
/// </summary>
internal static class OpenEditorService
{
    #region Init

    /// <summary>
    /// 使用这个方法执行控制台命令
    /// </summary>
    /// <param name="command"></param>
    [DllImport("msvcrt.dll", SetLastError = false
        , CallingConvention = CallingConvention.Cdecl
        , CharSet = CharSet.Ansi)]
    private static extern void system(string command);

    #endregion

    /// <summary>
    /// 将生成的文件打开
    /// </summary>
    public static void Execute()
    {
        var com = $"code {NoriScheduleConfiguration.MarkdownOutputPath}";
        system(com);

        com = $"code {NoriScheduleConfiguration.TextOutputPath}";
        system(com);
    }
}