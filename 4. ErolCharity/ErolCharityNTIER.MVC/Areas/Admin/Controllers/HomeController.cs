using ErolCharityNTIER.MVC.Areas.Admin.ViewModels;
using ErolCharityNTIER.DAL.Models;
using ErolCharityNTIER.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErolCharityNTIER.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected IWebHostEnvironment _webHostEnvironment;

    protected CauseService _causeService;

    public HomeController(IWebHostEnvironment webHostEnvironment)
    {
        _causeService = new();

        _webHostEnvironment = webHostEnvironment;
    }

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Causes"] = _causeService.GetAll();
        return View();
    }
    #endregion

    #region Create
    [HttpGet]
    public IActionResult CreateCause()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateCause")]
    public IActionResult PostCreateCause(HomeCreateCauseVM data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var creatingCause = new Cause()
        {
            Name = data.Name,
            Description = data.Description,
            Raised = data.Raised,
            Goal = data.Goal
        };
        SetCauseImage(data.Image, creatingCause);
        _causeService.Create(creatingCause);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult EditCause(int id)
    {
        var entity = _causeService.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity!);
    }

    [HttpPost]
    [ActionName("EditCause")]
    public IActionResult PostEditCause(int id, HomeEditCauseVM data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        if (data.Id != id)
        {
            return BadRequest();
        }
        var entity = _causeService.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        {
            if (data.Name != null)
            {
                entity.Name = data.Name;
            }
            if (data.Description != null)
            {
                entity.Description = data.Description;
            }
            if (data.Raised != null)
            {
                entity.Raised = data.Raised.Value;
            }
            if (data.Goal != null)
            {
                entity.Goal = data.Goal.Value;
            }
            if (data.Image != null)
            {
                SetCauseImage(data.Image!, entity);
            }
        }
        _causeService.Update(id, entity);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult DeleteCause(int id)
    {
        var entity = _causeService.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        _causeService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    [NonAction]
    public void SetCauseImage(IFormFile formFile, Cause cause)
    {
        if (formFile.Length == 0)
        {
            throw new InvalidDataException("The provided file is empty");
        }
        if (!formFile.ContentType.StartsWith("image/"))
        {
            throw new InvalidDataException("The provided file is not an image");
        }

        var basePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "causes");

        if (!System.IO.Directory.Exists(basePath))
        {
            System.IO.Directory.CreateDirectory(basePath);
        }

        if (cause.ImgFilename == string.Empty || !System.IO.File.Exists(cause.ImgFilename))
        {
            cause.ImgFilename = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(formFile.FileName)}";
        }

        var fileFullPath = Path.Combine(basePath, cause.ImgFilename);
        using (var creatingFile = System.IO.File.Open(fileFullPath, FileMode.Create))
        {
            formFile.CopyTo(creatingFile);
        }
    }
}
