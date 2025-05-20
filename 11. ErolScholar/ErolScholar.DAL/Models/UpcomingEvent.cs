namespace ErolScholar.DAL.Models;

public class UpcomingEvent : BaseModel
{
    public required string Name { get; set; }
    public required DateTime Date { get; set; }
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0.0m;
    public int Duration { get; set; } = 0;
    public string ImgFilename { get; set; } = string.Empty;
}
