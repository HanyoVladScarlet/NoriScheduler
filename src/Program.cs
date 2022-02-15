// See https://aka.ms/new-console-template for more information


using NoriScheduler.Services;
using Serilog;
using System.Reflection;

#region Init

// Serilog 初始化
Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Console()
    .CreateLogger();

Log.Information($"NoriScheduler Runs at version {0}",
    Assembly.GetExecutingAssembly().GetName().Version);
#endregion

await Output();

#if DEBUG
OpenEditorService.Execute();
#endif

// 打开外部编辑器
if (args.FirstOrDefault(x => x == "--open") != null)
{
    OpenEditorService.Execute();
}

#if DEBUG
Console.ReadLine();
#endif

// 主要方法
static async Task Output()
{
    var stalker = new StalkService(
        new FileService()
        , new JsonParseService()
        , new WebService()
    );

    await stalker.RunAsync();
}
