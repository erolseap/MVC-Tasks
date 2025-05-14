using ErolCharityNTIER.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolCharityNTIER.MVC.Controllers;

public class HomeController : Controller
{
    protected CauseService _causeService;

    public HomeController()
    {
        _causeService = new();
    }
 
    public IActionResult Index()
    {
        ViewData["Causes"] = _causeService.GetAll();
        return View();
    }
}
