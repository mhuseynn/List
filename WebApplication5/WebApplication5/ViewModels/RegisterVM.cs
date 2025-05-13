using System.ComponentModel.DataAnnotations;

namespace WebApplication5.ViewModels;

public class RegisterVM
{


    public string? Name { get; set; }

    public string? Surname { get; set; }


    public string? Username { get; set; }


    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [DataType(DataType.Password),Compare("ConfirmPassword")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }
}
