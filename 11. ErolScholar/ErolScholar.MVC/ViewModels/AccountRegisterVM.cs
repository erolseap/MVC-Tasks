using System.ComponentModel.DataAnnotations;

namespace ErolScholar.MVC.ViewModels;

public class AccountRegisterVM
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please specify username")]
    [MinLength(3)]
    [MaxLength(20)]
    public required string Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please specify email")]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password required to register")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
