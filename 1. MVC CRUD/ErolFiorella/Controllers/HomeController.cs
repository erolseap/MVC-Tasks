using ErolFiorella.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolFiorella.Controllers;
public class HomeController : Controller
{
    protected readonly FlowerEntryService _service = new();

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }
}
