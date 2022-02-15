namespace NoriScheduler.Models;

internal class IdolModel
{
    protected IdolModel(string id, string title, string mark, string thumbNail)
    {
        Id = id;
        Title = title;
        Mark = mark;
        ThumbNail = thumbNail;
    }

    public string Id { get; set; }
    public string Title { get; set; }
    public string Mark { get; set; }
    public string ThumbNail { get; set; }

    public static IdolModel CreateModel(string id, string mark, string thumbNail, string title)
    {
        return new IdolModel(id, title, mark, thumbNail);
    }
}