using ErolNFT.BL.Services;
using ErolNFT.DAL.Models;
using ErolNFT.MVC.Areas.Admin.ViewModels;

namespace ErolNFT.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected readonly IWebHostEnvironment _webHostEnvironment;
    protected readonly CollectionService _collectionService;

    public HomeController(IWebHostEnvironment webHostEnvironment, CollectionService collectionService)
    {
        _webHostEnvironment = webHostEnvironment;
        _collectionService = collectionService;
    }

    #region Create
    [HttpGet]
    [ActionName("CreateCollection")]
    public IActionResult GetCreateCollection()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateCollection")]
    public IActionResult PostCreateCollection(HomeCreateCollectionVM data)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "You didn't fill all required fields. Please, fill out all values");
            return View();
        }
        var model = new CollectionModel()
        {
            Name = data.Name,
            Category = data.Category,
            ItemsIn = data.ItemsIn,
            ItemsTotal = data.ItemsTotal
        };
        SetModelImage(model, data.Image);
        _collectionService.Create(model);
        return RedirectToAction("Index");

    }
    #endregion

    #region Read
    public IActionResult Index()
    {
        ViewData["Collections"] = _collectionService.GetAll();
        return View();
    }
    #endregion

    #region Update
    [HttpGet]
    [ActionName("EditCollection")]
    public IActionResult GetEditCollection(int id)
    {
        var model = _collectionService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model!);
    }

    [HttpPost]
    [ActionName("EditCollection")]
    public IActionResult PostEditCollection(int id, HomeEditCollectionVM data)
    {
        var model = _collectionService.GetById(id);
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
            if (data.Category != null)
            {
                model.Category = data.Category;
            }
            if (data.ItemsIn != null)
            {
                model.ItemsIn = data.ItemsIn.Value;
            }
            if (data.ItemsTotal != null)
            {
                model.ItemsTotal = data.ItemsTotal.Value;
            }
            if (data.Image != null)
            {
                SetModelImage(model, data.Image);
            }
        }
        _collectionService.Update(id, model);

        return RedirectToAction("Index");
    }
    #endregion

    #region Delete
    [HttpPost]
    [ActionName("DeleteCollection")]
    public IActionResult PostDeleteCollection(int id)
    {
        var model = _collectionService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        _collectionService.Delete(id);
        return RedirectToAction("Index");
    }
    #endregion

    [NonAction]
    public void SetModelImage(CollectionModel model, IFormFile formFile)
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

        var finalFullpath = Path.Combine(uploadsPath, fileName);

        using (var creatingFile = System.IO.File.Open(finalFullpath, FileMode.Create))
        {
            formFile.CopyTo(creatingFile);
        }

        model.ImgFilename = fileName;
    }
}
