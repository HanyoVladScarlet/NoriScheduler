using Serilog;

namespace NoriScheduler.Services;

internal class StalkService
{
    #region Init

    private readonly FileService _fileService;
    private readonly JsonParseService _jsonParseService;
    private readonly WebService _webService;

    public StalkService(FileService fileService
        , JsonParseService jsonParseService
        , WebService webService)
    {
        _fileService = fileService;
        _jsonParseService = jsonParseService;
        _webService = webService;
    }

    #endregion

    /// <summary>
    /// 执行获得节目单信息并输出到本地文档的方法
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        // 从远端获得json文本
        var input = await _webService.GetAsync();

        if (string.IsNullOrWhiteSpace(input))
        {
            Log.Error("从远端返回为空的数据，获取api失败。");
            return;
        }

        // 生成txt文件
        var text = _jsonParseService.ParseText(input);
        _fileService.CreateText(text);

        // 生成markdown文件
        text = _jsonParseService.ParseMarkdown(input);
        _fileService.CreatePdf(text);
    }
}