namespace WebIEEE.Domain.Entities;

public class News : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Uri ImageLink { get; set; }
    public string Author { get; set; }
}