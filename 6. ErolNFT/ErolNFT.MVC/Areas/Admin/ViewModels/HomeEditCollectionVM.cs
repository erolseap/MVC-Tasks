using System.ComponentModel.DataAnnotations;

namespace ErolNFT.MVC.Areas.Admin.ViewModels;

public class HomeEditCollectionVM
{
    [Required]
    public required int Id { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public int? ItemsIn { get; set; }

    public int? ItemsTotal { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }
}
