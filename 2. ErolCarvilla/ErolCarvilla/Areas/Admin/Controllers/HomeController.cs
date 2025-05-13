using ErolCarvilla.Areas.Admin.ViewModels;
using ErolCarvilla.Models;
using ErolCarvilla.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolCarvilla.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    private readonly IWebHostEnvironment _appEnvironment;

    protected readonly FeaturedCarsService _service = new();

    public HomeController(IWebHostEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }

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
    public IActionResult PostCreateFeaturedCar(HomeCreateFeaturedCarVM entry)
    {
        var createdCar = new FeaturedCar()
        {
            Name = entry.Name,
            Model = entry.Model,
            Price = entry.Price,
            HorsePower = entry.HorsePower,
            Mi = entry.Mi,
            IsManual = entry.IsManual,
            Description = entry.Description
        };

        var absPath = Path.Combine(_appEnvironment.WebRootPath, "assets", "uploaded");
        var generatedFileName = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(entry.Image.FileName)}";
        if (!Directory.Exists(absPath))
        {
            Directory.CreateDirectory(absPath);
        }

        using (var createdFile = System.IO.File.Open(Path.Combine(absPath, generatedFileName), FileMode.Create))
        {
            entry.Image.CopyTo(createdFile);
        }

        createdCar.ImageName = generatedFileName;

        _service.Create(createdCar);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
