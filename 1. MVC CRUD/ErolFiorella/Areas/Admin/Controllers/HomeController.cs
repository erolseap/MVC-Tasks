using ErolFiorella.Models;
using ErolFiorella.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolFiorella.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected readonly FlowerEntryService _service = new();

    #region Create
    [HttpGet]
    public IActionResult CreateFlowerEntry()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateFlowerEntry")]
    public IActionResult PostCreateFlowerEntry(FlowerEntry entry)
    {
        _service.Create(entry);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        return View(_service.GetAll());
    }
    #endregion

    #region Update
    // TODO
    #endregion

    #region Delete
    public IActionResult DeleteFlowerEntry(int id)
    {
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
