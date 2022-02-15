using Newtonsoft.Json.Linq;

namespace NoriScheduler.Services;

/// <summary>
/// 用于测试的类
/// </summary>
[Obsolete("仅用于测试！")]
internal class DemoService
{
    public static async Task Run()
    {
        using var client = new HttpClient();
        const string url = "https://schedule.noripro.jp/api/";


        var res = await client.GetAsync(url);
        Console.WriteLine(res.StatusCode);
        var input = await res.Content.ReadAsStringAsync();

        dynamic scheduleData = JObject.Parse(input);
        dynamic videos = scheduleData.videos;
        foreach (var item in videos)
        {
            if (item.liveBroadcastContent != "none")
            {
                Console.WriteLine(item.title);
            }
        }

        //Console.WriteLine(res);

        var lastUpdate = res.Content.Headers.LastModified ?? DateTimeOffset.UtcNow;
        Console.WriteLine(lastUpdate.ToLocalTime());


        var content = await client.GetStringAsync(url);
        //Console.WriteLine(content);

        var startTime = new DateTime(1970, 1, 1).ToLocalTime();
        Console.WriteLine(startTime.AddTicks(1644580800000 * 10000));

        //Console.WriteLine(dom.);
    }
}