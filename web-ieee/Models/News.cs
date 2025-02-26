namespace web_ieee.Models;

public class News
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoLink { get; set; }
    public DateTime CreatedAt { get; set; }
}