namespace ErolFashion.Models;

public class FeaturedProduct : BaseModel
{
    public required string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SmallNote { get; set; } = string.Empty;
    public string ImageName { get; set; } = "undefined.png";
}
