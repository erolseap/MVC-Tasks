namespace ErolFashion.Areas.Admin.ViewModels;

public class HomeEditFeaturedProductVM
{
    public required int Id { get; set; }
    public string? Name { get; set; } = null;
    public double? Price { get; set; } = null;
    public string? Description { get; set; } = null;
    public string? SmallNote { get; set; } = null;
    public IFormFile? Image { get; set; } = null;
}
