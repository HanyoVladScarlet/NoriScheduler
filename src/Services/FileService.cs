using Serilog;
using System.Text;

namespace NoriScheduler.Services;

/// <summary>
/// 用于输出文件到本地，默认路径为与应用程序同一文件夹下
/// </summary>
internal class FileService
{
    /// <summary>
    /// 输出用于预览网页的markdown文件
    /// </summary>
    /// <param name="input"></param>
    public void CreateMarkdown(string input)
    {
        try
        {
            var path = NoriScheduleConfiguration.MarkdownOutputPath;

            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            var buffer = Encoding.UTF8.GetBytes(input);
            fs.Write(buffer, 0, buffer.Length);
            Log.Information("已生成markdown文件：" +
                            "{0}！", path);
        }
        catch (Exception e)
        {
            Log.Error("生成markdown文件失败...");
            Log.Error(e.Message);
        }
    }

    /// <summary>
    /// 输出可用于b站动态的raw文本文件
    /// </summary>
    /// <param name="input"></param>
    public void CreateText(string input)
    {
        try
        {
            var path = NoriScheduleConfiguration.TextOutputPath;

            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            var buffer = Encoding.UTF8.GetBytes(input);
            fs.Write(buffer, 0, buffer.Length);
            Log.Information("已生成txt文件：" +
                            "{0}！", path);
        }
        catch (Exception e)
        {
            Log.Error("生成txt文件失败...");
            Log.Error(e.Message);
        }
    }
}

// TODO: 修改并美化预览方法