using System.ComponentModel.DataAnnotations;

namespace ErolVilla.MVC.Areas.Admin.ViewModels;

public class HomeCreateHouseVM
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Ismi qeyd edin")]
    public required string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Note-u adi qeyd edin")]
    public required string Note { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Qiymeti qeyd edin")]
    public required decimal Price { get; set; }

    [Required(ErrorMessage = "Yataq otaqlarin sayini qeyd edin")]
    public required int BedroomsCount { get; set; }

    [Required(ErrorMessage = "Hamamlarin sayini qeyd edin")]

    public required int BathroomsCount { get; set; }

    [Required(ErrorMessage = "Erazi olcusunu qeyd edin")]
    public required int Area { get; set; }

    [Required(ErrorMessage = "Mertebeni qeyd edin")]
    public required int Floor { get; set; }

    [Required(ErrorMessage = "Parking yerlerin sayini qeyd edin")]
    public required int ParkingSpotsCount { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Collection-un seklini qeyd edin")]
    [DataType(DataType.Upload)]
    public required IFormFile Image { get; set; }
}
