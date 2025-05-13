using ErolCarvilla.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolCarvilla.Controllers;
public class HomeController : Controller
{
    protected readonly FeaturedCarsService _service = new();

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }
}
