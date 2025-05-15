using ErolGYM.BL.Services;

namespace ErolGYM.MVC.Controllers;

public class HomeController : Controller
{
    protected readonly GymProgramService _service;

    public HomeController(GymProgramService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewData["GymPrograms"] = _service.GetAll();
        return View();
    }
}
