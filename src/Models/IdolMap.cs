namespace NoriScheduler.Models;

internal static class IdolMap
{
    private static readonly IdolModel[] Models = new[]
    {
        IdolModel.CreateModel(
            "UCBAeKqEIugv69Q2GIgcH7oA",
            "👿⚜️",
            "https://yt3.ggpht.com/dxAjuUoNZLjOkfuWiUNBCj2tSfdIHun6_RyYP_5buDaONwGVdXSDmgdPoFxORaWaPr8kvfUh-Q=s240-c-k-c0x00ffffff-no-rj",
            "逢魔きららOma Kirara"
            ),
        IdolModel.CreateModel(
            "UCLyTXfCZtl7dyhta9Jg3pZg",
            "👹🌛",
            "https://yt3.ggpht.com/QUxBOZ26kqXsOt8DpIC36U4J3XGNgqWy2zvZPn7OgMa1f7r3tBT6rXJrDNZdOx29ZShKpbGv=s240-c-k-c0x00ffffff-no-rj",
            "鬼灯わらべ"
        ),
        IdolModel.CreateModel(
            "UCCXME7oZmXB2VFHJbz5496A",
            "🐻🍨",
            "https://yt3.ggpht.com/zwukbFa_AOmC_C176ce46xel1hxoP7Xbnv6vg3AayenzI8Ia26BTtBM0p0k74NKB1ZYJDAGwFA=s240-c-k-c0x00ffffff-no-rj",
            "熊谷タクマ"
            ),
        IdolModel.CreateModel(
            "UCMxIxoMdtcLkZ1wTq7qjztg",
            "🐈🎩",
            "https://yt3.ggpht.com/BjJW0Cj304syKOX4GsvtfmOxJtwYSoZ0Qn-MZL2KUFZWqKhu40RhRYb0DbfiflZwuMlsiilE=s240-c-k-c0x00ffffff-no-rj",
            "猫瀬乃しん"
        ),IdolModel.CreateModel(
            "UCle1cz6rcyH0a-xoMYwLlAg",
            "🐰✍️",
            "https://yt3.ggpht.com/RGKeCoXpt-ikhbAarcy4YCFiZdIiJI8i_hRTaycPPPQkiHdTFnGgs-tUAbCEX7GinByICJESIA=s240-c-k-c0x00ffffff-no-rj",
            "姫咲ゆずる"
        ),IdolModel.CreateModel(
            "UCC0i9nECi4Gz7TU63xZwodg",
            "🐶❄️",
            "https://yt3.ggpht.com/oVW2wPwqDHrRHEbdNbw9NXHW8ogIxId1zcE_9RbJlonWJVNFPOySVGgQIiYAsKy5Cr8r66trrw=s240-c-k-c0x00ffffff-no-rj",
            "白雪みしろ"
        ),IdolModel.CreateModel(
            "UCxrmkJf_X1Yhte_a4devFzA",
            "🎀🌟",
            "https://yt3.ggpht.com/FNyYBDP3x5f6VY1CpEkZaXNKGV8pRIQaGuQ_hBRcjJp6UQuYGlymcuB1VtObCP77QoQ-njxx=s240-c-k-c0x00ffffff-no-rj",
            "胡桃澤もも"
        ),IdolModel.CreateModel(
            "UCuycJ_IsA5ESbTYhe05ozqQ",
            "🔔🐾",
            "https://yt3.ggpht.com/N1z6a6Kjh5-tPRB0X0kTdRtYiwhEPUunq74QISpx6CZxx9MhWrfQ1I8XBITTJ1Y6T2ixhNQmGQ=s240-c-k-c0x00ffffff-no-rj",
            "レグルシュ・ライオンハート"
        ),IdolModel.CreateModel(
            "UCIRzELGzTVUOARi3Gwf1-yg",
            "🌙💗",
            "https://yt3.ggpht.com/sY2xmTP-lnCZEToJxCPMG7-kR93BEoDFwIPHQvIwuHi5c-ndnd2bm96MCXGTyhv751ESjiG8ig=s240-c-k-c0x00ffffff-no-rj",
            "看谷にぃあ"
        ),IdolModel.CreateModel(
            "UCWIPfdcux1WxuX5yZLPJDww",
            "🦊🍂",
            "https://yt3.ggpht.com/GoJAMM2gbVnT1fNzXW5kczP8yAOrtkha0j0Ex_1sEhBPji80nC5vwygCAP-jWd6NRxZ7yv75vg=s240-c-k-c0x00ffffff-no-rj",
            "稲荷いろは"
        ),IdolModel.CreateModel(
            "UCJCzy0Fyrm0UhIrGQ7tHpjg",
            "🍼💖",
            "https://yt3.ggpht.com/czgp_vFoedwbEb9eV5rhbJ_QY-OmAdahgB8y12srTmv1XgtxRZ98dIAPuZL-uKuTmCl6mWoKRyE=s240-c-k-c0x00ffffff-no-rj",
            "愛宮みるく"
        ),IdolModel.CreateModel(
            "UC8NZiqKx6fsDT3AVcMiVFyA",
            "🐶💙",
            "https://yt3.ggpht.com/ccgxjPnCeYO5o6WmTfu6mt9gjWtqF67H3_OpJbjAxPlvbAMIoHxsfLIRNBa-mn-R6rBu8_iLUNY=s240-c-k-c0x00ffffff-no-rj",
            "犬山たまき"
        ),

    };
    public static IdolModel? GetIdol(string id)
    {
        return Models.FirstOrDefault(x => x.Id == id);
    }
}