using ErolGYM.BL.Services;
using ErolGYM.DAL.Models;
using ErolGYM.MVC.Areas.Admin.ViewModels;

namespace ErolGYM.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected readonly IWebHostEnvironment _webHostEnvironment;
    protected readonly GymProgramService _service;

    public HomeController(IWebHostEnvironment webHostEnvironment, GymProgramService service)
    {
        _webHostEnvironment = webHostEnvironment;
        _service = service;
    }

    #region Create
    [HttpGet]
    [ActionName("CreateProgram")]
    public IActionResult CreateProgram()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateProgram")]
    public IActionResult PostCreateProgram(HomeCreateProgramVM data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var model = new GymProgram()
        {
            Name = data.Name,
            Description = data.Description
        };
        SetModelImage(model, data.Image);
        _service.Create(model);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["GymPrograms"] = _service.GetAll();
        return View();
    }
    #endregion

    #region Update
    [HttpGet]
    [ActionName("EditProgram")]
    public IActionResult EditProgram(int id)
    {
        var model = _service.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model!);
    }

    [HttpPost]
    [ActionName("EditProgram")]
    public IActionResult PostEditProgram(int id, HomeEditProgramVM data)
    {
        if (!ModelState.IsValid || id != data.Id)
        {
            return BadRequest();
        }
        var model = _service.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        {
            if (data.Name is not null)
            {
                model.Name = data.Name;
            }
            if (data.Description is not null)
            {
                model.Description = data.Description;
            }
            if (data.Image is not null)
            {
                SetModelImage(model, data.Image);
            }
        }
        _service.Update(id, model);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpPost]
    [ActionName("DeleteProgram")]
    public IActionResult PostDeleteProgram(int id)
    {
        if (_service.GetById(id) == null)
        {
            return NotFound();
        }
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    [NonAction]
    public void SetModelImage(GymProgram model, IFormFile formFile)
    {
        var rootPath = _webHostEnvironment.WebRootPath;
        var uploadPath = Path.Combine(rootPath, "assets", "uploads");

        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        var imgFileName = model.ImgFilename;
        if (imgFileName == "default.png")
        {
            imgFileName = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(formFile.FileName)}";
        }
        var imgFullPath = Path.Combine(uploadPath, imgFileName);

        using (var file = System.IO.File.Open(imgFullPath, FileMode.Create))
        {
            formFile.CopyTo(file);
        }

        model.ImgFilename = imgFileName;
    }
}
