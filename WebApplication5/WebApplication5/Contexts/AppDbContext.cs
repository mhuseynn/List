using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models.Concretes;

namespace WebApplication5.Contexts;

public class AppDbContext : IdentityDbContext<AppUser,IdentityRole,string>
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }


    public DbSet<Person> Persons { get; set; }
}
