using ErolFashion.Areas.Admin.ViewModels;
using ErolFashion.Models;
using ErolFashion.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolFashion.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    private readonly IWebHostEnvironment _appEnvironment;

    protected readonly FeaturedProductService _service;

    public HomeController(IWebHostEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
        _service = new();
    }

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["FeaturedProducts"] = _service.GetAll();
        return View();
    }
    #endregion

    #region Create
    [HttpGet]
    public IActionResult CreateFeaturedProduct()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateFeaturedProduct")]
    public IActionResult PostCreateFeaturedProduct(HomeCreateFeaturedProductVM entry)
    {
        var createdEntity = new FeaturedProduct()
        {
            Name = entry.Name,
            Price = entry.Price,
            Description = entry.Description ?? string.Empty,
            SmallNote = entry.SmallNote ?? string.Empty
        };

        var absPath = Path.Combine(_appEnvironment.WebRootPath, "assets", "uploaded");
        var generatedFileName = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(entry.Image.FileName)}";
        if (!Directory.Exists(absPath))
        {
            Directory.CreateDirectory(absPath);
        }

        var absCreatingFilePath = Path.Combine(absPath, generatedFileName);

        using (var createdFile = System.IO.File.Open(absCreatingFilePath, FileMode.Create))
        {
            entry.Image.CopyTo(createdFile);
        }

        createdEntity.ImageName = generatedFileName;

        _service.Create(createdEntity);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult EditFeaturedProduct(int id)
    {
        var product = _service.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product!);
    }

    [HttpPost]
    [ActionName("EditFeaturedProduct")]
    public IActionResult PostEditFeaturedProduct(int id, HomeEditFeaturedProductVM data)
    {
        if (id != data.Id)
        {
            return BadRequest();
        }
        var existingProduct = _service.GetById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        {
            if (data.Name != null)
            {
                existingProduct.Name = data.Name!;
            }
            if (data.Price != null)
            {
                existingProduct.Price = data.Price.Value;
            }
            if (data.Description != null)
            {
                existingProduct.Description = data.Description!;
            }
            if (data.SmallNote != null)
            {
                existingProduct.SmallNote = data.SmallNote!;
            }

            if (data.Image != null)
            {
                var absPath = Path.Combine(_appEnvironment.WebRootPath, "assets", "uploaded");
                var generatedFileName = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(data.Image.FileName)}";
                if (!Directory.Exists(absPath))
                {
                    Directory.CreateDirectory(absPath);
                }

                var absCreatingFilePath = Path.Combine(absPath, generatedFileName);

                using (var createdFile = System.IO.File.Open(absCreatingFilePath, FileMode.Create))
                {
                    data.Image.CopyTo(createdFile);
                }

                existingProduct.ImageName = generatedFileName;
            }
        }

        _service.Update(id, existingProduct);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult DeleteFeaturedProduct(int id)
    {
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
