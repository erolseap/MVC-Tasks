namespace ErolCharityNTIER.MVC.Areas.Admin.ViewModels;

public class HomeEditCauseVM
{
    public required int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Raised { get; set; }
    public decimal? Goal { get; set; }
    public IFormFile? Image { get; set; }
}
