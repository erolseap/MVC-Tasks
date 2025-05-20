using System.ComponentModel.DataAnnotations;

namespace ErolScholar.MVC.Areas.Admin.ViewModels;

public class HomeEditUpcomingEventVM
{
    [Required]
    public required int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? Duration { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }
}
