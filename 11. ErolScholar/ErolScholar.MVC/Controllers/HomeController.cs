using ErolScholar.BL.Services;

namespace ErolScholar.MVC.Controllers;

public class HomeController : Controller
{
    protected readonly UpcomingEventService _ueService;

    public HomeController(UpcomingEventService ueService)
    {
        _ueService = ueService;
    }

    public IActionResult Index()
    {
        ViewData["UpcomingEvents"] = _ueService.GetAll();
        return View();
    }
}
