using System.ComponentModel.DataAnnotations;

namespace ErolScholar.MVC.Areas.Admin.ViewModels;

public class HomeCreateUpcomingEventVM
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Eventin adini qeyd edin")]
    public required string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Tarixi qeyd edin")]
    public required DateTime Date { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Category adini qeyd edin")]
    public required string Category { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Qiymeti qeyd edin")]
    public required decimal Price { get; set; }

    [Required(ErrorMessage = "Vaxt muddetini qeyd edin")]
    public required int Duration { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Sekili qeyd edin")]
    [DataType(DataType.Upload)]
    public required IFormFile Image { get; set; }
}
