using Serilog;
using System.Net;

namespace NoriScheduler.Services;

/// <summary>
/// 用于从接口 https://schedule.noripro.jp/api/ 获得json文本
/// </summary>
internal class WebService
{
    /// <summary>
    /// 从接口 https://schedule.noripro.jp/api/ 获得json文本
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetAsync()
    {
        try
        {
            using var client = new HttpClient();
            var url = new Uri("https://schedule.noripro.jp/api/");

            var res = await client.GetAsync(url);

            // 若状态码正常，则返回得到的json文本
            if (res.StatusCode != HttpStatusCode.OK)
            {
                return await res.Content.ReadAsStringAsync();
            }
            Log.Error("位于：{0} 的Api获取失败，" +
                      "状态码为：{1}，请检查网络情况或更换代理！",
                url.AbsoluteUri, res.StatusCode);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
        return string.Empty;
    }
}