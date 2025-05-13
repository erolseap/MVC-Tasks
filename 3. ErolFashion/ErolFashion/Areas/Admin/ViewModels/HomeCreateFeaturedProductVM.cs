namespace ErolFashion.Areas.Admin.ViewModels;

public class HomeCreateFeaturedProductVM
{
    public required string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SmallNote { get; set; } = string.Empty;
    public required IFormFile Image { get; set; }
}
