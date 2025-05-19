using System.ComponentModel.DataAnnotations;

namespace ErolVilla.MVC.Areas.Admin.ViewModels;

public class HomeEditHouseVM
{
    [Required]
    public required int Id { get; set; }

    public string? Name { get; set; }

    public string? Note { get; set; }

    public decimal? Price { get; set; }

    public int? BedroomsCount { get; set; }

    public int? BathroomsCount { get; set; }

    public int? Area { get; set; }

    public int? Floor { get; set; }

    public int? ParkingSpotsCount { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }
}
