using ErolFashion.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolFashion.Controllers;
public class HomeController : Controller
{
    protected readonly FeaturedProductService _service;

    public HomeController()
    {
        _service = new();
    }

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }
}
