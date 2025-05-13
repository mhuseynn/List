


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Contexts;
using WebApplication5.Models.Concretes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("server=.;database=AppDB;Integrated Security=true;Encrypt=false;Trust Server Certificate=true");
});


builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
{
    op.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller}/{action}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
   pattern: "{controller}/{action}");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
