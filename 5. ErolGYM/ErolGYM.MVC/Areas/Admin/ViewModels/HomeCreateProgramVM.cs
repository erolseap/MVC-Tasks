using System.ComponentModel.DataAnnotations;

namespace ErolGYM.MVC.Areas.Admin.ViewModels;

public class HomeCreateProgramVM
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required IFormFile Image { get; set; }
}
