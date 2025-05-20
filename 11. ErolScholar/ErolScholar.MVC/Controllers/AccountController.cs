using ErolScholar.BL.Services;
using ErolScholar.DAL.Models;
using ErolScholar.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ErolScholar.MVC.Controllers;

public class AccountController : Controller
{
    protected readonly UserManager<UserModel> _userManager;
    protected readonly SignInManager<UserModel> _signInManager;

    public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    #region Login
    [HttpGet]
    [ActionName("Login")]
    public IActionResult GetLogin()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Login")]
    public async Task<IActionResult> PostLogin(AccountLoginVM data)
    {
        var user = (await _userManager.FindByEmailAsync(data.UsernameOrEmail)) ?? (await _userManager.FindByNameAsync(data.UsernameOrEmail));
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "The specified user was not found");
            return View();
        }
        var authResult = await _signInManager.PasswordSignInAsync(user!, data.Password, false, false);
        if (!authResult.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Incorrect password");
            return View();
        }
        return RedirectToAction("Index", controllerName: "Home");
    }
    #endregion

    #region Register
    [HttpGet]
    [ActionName("Register")]
    public IActionResult GetRegister()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Register")]
    public async Task<IActionResult> PostRegister(AccountRegisterVM data)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Please fill all required fields");
            return View();
        }
        var user = new UserModel()
        {
            UserName = data.Username,
            Email = data.Email
        };
        var registerResult = await _userManager.CreateAsync(user, data.Password);
        if (!registerResult.Succeeded)
        {
            foreach (var err in registerResult.Errors)
            {  
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View();
        }
        return RedirectToAction("Index", controllerName: "Home");
    }
    #endregion
}
