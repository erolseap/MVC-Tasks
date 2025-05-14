namespace ErolCharityNTIER.MVC.Areas.Admin.ViewModels;

public class HomeCreateCauseVM
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Raised { get; set; } = 0.0m;
    public decimal Goal { get; set; } = 0.0m;
    public required IFormFile Image { get; set; }
}
