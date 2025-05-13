using ErolCarvilla.Models;
using ErolCarvilla.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolCarvilla.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected readonly FeaturedCarsService _service = new();

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["FeaturedCars"] = _service.GetAll();
        return View();
    }
    #endregion

    #region Create
    [HttpGet]
    public IActionResult CreateFeaturedCar()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateFeaturedCar")]
    public IActionResult PostCreateFeaturedCar(FeaturedCar entry)
    {
        _service.Create(entry);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
