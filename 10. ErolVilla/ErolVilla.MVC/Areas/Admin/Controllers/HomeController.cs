using ErolVilla.BL.Services;
using ErolVilla.DAL.Models;
using ErolVilla.MVC.Areas.Admin.ViewModels;

namespace ErolVilla.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    protected readonly IWebHostEnvironment _webHostEnvironment;
    protected readonly HouseService _houseService;

    public HomeController(IWebHostEnvironment webHostEnvironment, HouseService houseService)
    {
        _webHostEnvironment = webHostEnvironment;
        _houseService = houseService;
    }

    #region Create
    [HttpGet]
    [ActionName("CreateHouse")]
    public IActionResult GetCreateHouse()
    {
        return View();
    }

    [HttpPost]
    [ActionName("CreateHouse")]
    public IActionResult PostCreateHouse(HomeCreateHouseVM data)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Please, fill all values");
            return View();
        }
        var model = new HouseModel()
        {
            Name = data.Name,
            Note = data.Note,
            Price = data.Price,
            BedroomsCount = data.BedroomsCount,
            BathroomsCount = data.BathroomsCount,
            Area = data.Area,
            Floor = data.Floor,
            ParkingSpotsCount = data.ParkingSpotsCount
        };
        SetHouseImage(model, data.Image);
        _houseService.Create(model);
        return RedirectToAction("Index");

    }
    #endregion

    #region Read
    public IActionResult Index()
    {
        ViewData["Houses"] = _houseService.GetAll();
        return View();
    }
    #endregion

    #region Update
    [HttpGet]
    [ActionName("EditHouse")]
    public IActionResult GetEditHouse(int id)
    {
        var model = _houseService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model!);
    }

    [HttpPost]
    [ActionName("EditHouse")]
    public IActionResult PostEditHouse(int id, HomeEditHouseVM data)
    {
        var model = _houseService.GetById(id);
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
            if (data.Note != null)
            {
                model.Note = data.Note;
            }
            if (data.Price != null)
            {
                model.Price = data.Price.Value;
            }
            if (data.BedroomsCount != null)
            {
                model.BedroomsCount = data.BedroomsCount.Value;
            }
            if (data.BathroomsCount != null)
            {
                model.BathroomsCount = data.BathroomsCount.Value;
            }
            if (data.Area != null)
            {
                model.Area = data.Area.Value;
            }
            if (data.Floor != null)
            {
                model.Floor = data.Floor.Value;
            }
            if (data.ParkingSpotsCount != null)
            {
                model.ParkingSpotsCount = data.ParkingSpotsCount.Value;
            }
            if (data.Image != null)
            {
                SetHouseImage(model, data.Image);
            }
        }
        _houseService.Update(id, model);

        return RedirectToAction("Index");
    }
    #endregion

    #region Delete
    [HttpPost]
    [ActionName("DeleteHouse")]
    public IActionResult PostDeleteHouse(int id)
    {
        var model = _houseService.GetById(id);
        if (model == null)
        {
            return NotFound();
        }
        _houseService.Delete(id);
        return RedirectToAction("Index");
    }
    #endregion

    [NonAction]
    public void SetHouseImage(HouseModel model, IFormFile formFile)
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
