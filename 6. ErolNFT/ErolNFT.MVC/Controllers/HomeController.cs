using ErolNFT.BL.Services;

namespace ErolNFT.MVC.Controllers;

public class HomeController : Controller
{
    protected readonly CollectionService _collectionService;

    public HomeController(CollectionService collectionService)
    {
        _collectionService = collectionService;
    }

    public IActionResult Index()
    {
        ViewData["Collections"] = _collectionService.GetAll();
        return View();
    }
}
