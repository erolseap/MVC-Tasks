using System.ComponentModel.DataAnnotations;

namespace ErolNFT.MVC.Areas.Admin.ViewModels;

public class HomeCreateCollectionVM
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Ismi qeyd edin")]
    public required string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Category adi qeyd edin")]
    public required string Category { get; set; }

    public int ItemsIn { get; set; } = 0;

    public int ItemsTotal { get; set; } = 0;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Collection-un seklini qeyd edin")]
    [DataType(DataType.Upload)]
    public required IFormFile Image { get; set; }
}
