using System.ComponentModel.DataAnnotations;

namespace ErolScholar.MVC.ViewModels;

public class AccountLoginVM
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please specify username or email")]
    public required string UsernameOrEmail { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password required to authorize")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
