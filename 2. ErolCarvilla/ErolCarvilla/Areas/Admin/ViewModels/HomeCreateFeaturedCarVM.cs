namespace ErolCarvilla.Areas.Admin.ViewModels;

public class HomeCreateFeaturedCarVM
{
    public required string Name { get; set; }
    public int Model { get; set; }
    public double Price { get; set; }
    public int HorsePower { get; set; }
    public int Mi { get; set; }
    public bool IsManual { get; set; }
    public string Description { get; set; } = string.Empty;
    public required IFormFile Image { get; set; }
}
