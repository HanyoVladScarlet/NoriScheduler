using Newtonsoft.Json.Linq;
using NoriScheduler.Models;
using Serilog;
using System.Globalization;
using System.Text;

namespace NoriScheduler.Services;

/// <summary>
/// 对从 https://schedule.noripro.jp/api/ 获得的json文件进行解析
/// </summary>
internal class JsonParseService
{
    /// <summary>
    /// 使用这个方法获得raw的b站动态文本
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string ParseText(string input)
    {
        dynamic schedule = JObject.Parse(input);
        var videos = schedule.videos;

        var sb = new StringBuilder();
        sb.AppendLine($"🌞～本日{DateTime.Now.Month}/" +
                      $"{DateTime.Now.Day}的直播预告～🌞")
            .AppendLine();

        foreach (var video in videos)
        {
            if (video.liveBroadcastContent == "none")
            {
                continue;
            }

            IdolModel idol = IdolMap.GetIdol(video.channelId.ToString());
            DateTime dateTime = GetLocalTime(video.timestamp.ToString());

            if (dateTime.Day > DateTime.Now.Day)
            {
                sb.Append("（次日）");
            }
            var hour = dateTime.Hour.ToString()
                .PadLeft(2, '0');
            var minute = dateTime.Minute.ToString()
                .PadLeft(2, '0');
            var time = $"{hour}:{minute}";
            string title = video.title.ToString();

            sb.Append(time)
                .Append('~')
                .Append(idol.Title)
                .Append(idol.Mark)
                .Append("you");

            if (video.members != null)
            {
                Log.Warning("检测到于 {0} 播出的节目" +
                            "{1}存在联动对象，请手动添加！",
                    time, title);
                sb.Append("（联动对象：【】）");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    /// <summary>
    /// 使用这个方法来获得简单的.md格式预览文件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string ParseMarkdown(string input)
    {
        dynamic schedule = JObject.Parse(input);
        var videos = schedule.videos;

        var sb = new StringBuilder();

        // 图片的样式，主要设置宽度
        sb.AppendLine("<style>\nimg{\nwidth: 300px;" +
                      "\n}\n</style>\n");

        // 标题
        sb.AppendLine($"🌞～本日{DateTime.Now.Month}/" +
                      $"{DateTime.Now.Day}的直播预告～🌞")
            .AppendLine()
            .AppendLine($"官网链接：https://schedule.noripro.jp/");

        foreach (var video in videos)
        {
            // 如果直播内容标记为none则是已经直播过的内容
            if (video.liveBroadcastContent == "none")
            {
                continue;
            }

            // 获得ytb封面缓存的视频id
            string liveId = video.id.ToString();
            liveId = string.Concat(liveId.Reverse()); // api中图片的id需要反转
            var url = $"https://www.youtube.com/watch?v={liveId}";

            // 提示正在直播的节目
            if (video.liveBroadcastContent == "live")
            {
                Log.Information("检测到一个直播正在进行，" +
                                "直播间地址为：/n{0}", url);
                continue;
            }

            // 获得ytb封面缓存的图片文件名
            string thumbNail = video.thumbnail.ToString();

            // 直播间标题
            string title = video.title.ToString();

            // 直播时间
            DateTime dateTime = GetLocalTime(video.timestamp.ToString());

            sb.AppendLine("---")
                .AppendLine(dateTime
                    .ToString(CultureInfo.CurrentCulture))
                .AppendLine($"![](https://i.ytimg.com/vi/" +
                            $"{liveId}/{thumbNail})")
                .AppendLine(title)
                .AppendLine(url)
                .AppendLine();
        }

        return sb.ToString();
    }

    /// <summary>
    /// 将时间戳转换为本地时间
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    private static DateTime GetLocalTime(string timeStamp)
    {
        try
        {
            var time = long.Parse(timeStamp);
            var startTime = new DateTime(1970, 1, 1).ToLocalTime();
            return startTime.AddTicks(time * 10000);

        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return DateTime.MinValue;
        }
    }
}

// TODO: 该接口不具备区分直播还是视频的能力，应实现
