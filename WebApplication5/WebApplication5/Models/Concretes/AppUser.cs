using Microsoft.AspNetCore.Identity;
using WebApplication5.Models.Abstracts;

namespace WebApplication5.Models.Concretes;

public class AppUser : IdentityUser
{
    public string? Name { get; set; }

    public string? Surname { get; set; }
}
