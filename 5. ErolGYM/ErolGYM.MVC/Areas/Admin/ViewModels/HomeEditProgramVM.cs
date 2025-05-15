using System.ComponentModel.DataAnnotations;

namespace ErolGYM.MVC.Areas.Admin.ViewModels;

public class HomeEditProgramVM
{
    [Required]
    public required int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IFormFile? Image { get; set; }
}
