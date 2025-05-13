using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers;

[Authorize(Roles = "Admin,User")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
