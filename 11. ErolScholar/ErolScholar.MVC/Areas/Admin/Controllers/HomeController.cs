using ErolScholar.BL.Services;
using ErolScholar.DAL.Models;
using ErolScholar.MVC.Areas.Admin.ViewModels;

namespace ErolScholar.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected readonly IWebHostEnvironment _webHostEnvironment;
    protected readonly UpcomingEventService _ueService;

    public HomeController(IWebHostEnvironment webHostEnvironment, UpcomingEventService ueService)
    {
        _webHostEnvironment = webHostEnvironment;
        _ueService = ueService;
    }

    #region Create
    [HttpGet]
    [ActionName("CreateUpcomingEvent")]
    public IActionResult GetCreateUpcomingEvent()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateUpcomingEvent")]
    public IActionResult PostCreateUpcomingEvent(HomeCreateUpcomingEventVM data)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Please, fill all values");
            return View();
        }
        var model = new UpcomingEvent()
        {
            Name = data.Name,
            Category = data.Category,
            Date = data.Date,
            Price = data.Price,
            Duration = data.Duration
        };
        SetEventImage(model, data.Image);
        _ueService.Create(model);
        return RedirectToAction("Index");

    }
    #endregion

    #region Read
    public IActionResult Index()
    {
        ViewData["UpcomingEvents"] = _ueService.GetAll();
        return View();
    }
    #endregion

    #region Update
    [HttpGet]
    [ActionName("EditUpcomingEvent")]
    public IActionResult GetEditUpcomingEvent(int id)
    {
        var model = _ueService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model!);
    }

    [HttpPost]
    [ActionName("EditUpcomingEvent")]
    public IActionResult PostEditUpcomingEvent(int id, HomeEditUpcomingEventVM data)
    {
        var model = _ueService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        if (id != data.Id)
        {
            return BadRequest();
        }
        {
            if (data.Name != null)
            {
                model.Name = data.Name;
            }
            if (data.Date != null)
            {
                model.Date = data.Date.Value;
            }
            if (data.Category != null)
            {
                model.Category = data.Category;
            }
            if (data.Price != null)
            {
                model.Price = data.Price.Value;
            }
            if (data.Duration != null)
            {
                model.Duration = data.Duration.Value;
            }
            if (data.Image != null)
            {
                SetEventImage(model, data.Image);
            }
        }
        _ueService.Update(id, model);

        return RedirectToAction("Index");
    }
    #endregion

    #region Delete
    [HttpPost]
    [ActionName("DeleteUpcomingEvent")]
    public IActionResult PostDeleteUpcomingEvent(int id)
    {
        var model = _ueService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        _ueService.Delete(id);
        return RedirectToAction("Index");
    }
    #endregion

    [NonAction]
    public void SetEventImage(UpcomingEvent model, IFormFile formFile)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        if (formFile == null)
        {
            throw new ArgumentNullException(nameof(formFile));
        }

        if (!formFile.ContentType.StartsWith("image/"))
        {
            throw new ArgumentException("The provided file must be an image");
        }

        var basePath = _webHostEnvironment.WebRootPath;
        var uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "uploads");
        if (!Directory.Exists(uploadsPath))
        {
            Directory.CreateDirectory(uploadsPath);
        }

        var fileName = model.ImgFilename;
        if (fileName == string.Empty || fileName == "default.png")
        {
            fileName = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(formFile.FileName)}";
        }

        var finalFileFullpath = Path.Combine(uploadsPath, fileName);

        using (var creatingFile = System.IO.File.Open(finalFileFullpath, FileMode.Create))
        {
            formFile.CopyTo(creatingFile);
        }

        model.ImgFilename = fileName;
    }
}
