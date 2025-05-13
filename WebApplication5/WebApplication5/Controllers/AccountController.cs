using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication5.Contexts;
using WebApplication5.Models.Concretes;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers;

public class AccountController : Controller
{
    UserManager<AppUser> _userManager;
    SignInManager<AppUser> _signInManager;
    RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVm)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        var us = await _userManager.FindByEmailAsync(loginVm.Email!);

        if (us != null)
        {
            var result = await _signInManager.PasswordSignInAsync(us, loginVm.Password!, loginVm.IsRememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
        }

        return View();
    }


    public async Task<ActionResult> CreateRoles()
    {
        if (ModelState.IsValid)
        {
            var role = new IdentityRole("Admin");
            var role2 = new IdentityRole("User");
            var roleresult = await _roleManager.CreateAsync(role);
            var roleresult2 = await _roleManager.CreateAsync(role2);
            if (!roleresult.Succeeded && !roleresult2.Succeeded)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        return View();
    }



    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if(!ModelState.IsValid)
        {
            return View();
        }
        
        AppUser appUser = new AppUser()
        {
            Name = registerVM.Name,
            Email = registerVM.Email,
            Surname = registerVM.Surname,
            UserName = registerVM.Username,
        };

        var result = await _userManager.CreateAsync(appUser, registerVM.Password!);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(appUser, "User");
            return RedirectToAction("Login");
        }

        return View();
    }


}
