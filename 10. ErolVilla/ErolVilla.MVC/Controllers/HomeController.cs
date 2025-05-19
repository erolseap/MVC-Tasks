using ErolVilla.BL.Services;

namespace ErolVilla.MVC.Controllers;

public class HomeController : Controller
{
    protected readonly HouseService _collectionService;

    public HomeController(HouseService collectionService)
    {
        _collectionService = collectionService;
    }

    public IActionResult Index()
    {
        ViewData["Houses"] = _collectionService.GetAll();
        return View();
    }
}
