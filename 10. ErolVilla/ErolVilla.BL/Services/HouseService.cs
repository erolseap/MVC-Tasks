using ErolVilla.DAL.Contexts;
using ErolVilla.DAL.Models;

namespace ErolVilla.BL.Services;

public class HouseService
{
    protected readonly AppDbContext _context;

    public HouseService(AppDbContext context)
    {
        _context = context;
    }

    #region Create
    public void Create(HouseModel model)
    {
        _context.Houses.Add(model);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public HouseModel? GetById(int id) => _context.Houses.Find(id);
    public List<HouseModel> GetAll() => _context.Houses.ToList();
    #endregion

    #region Update
    public void Update(int id, HouseModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        if (id != model.Id)
        {
            throw new ArgumentException("Argument id must match with model id");
        }
        if (GetById(id) != model)
        {
            throw new ArgumentException("The provided model reference must match with the tracking one");
        }
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        var model = GetById(id);
        if (model == null) return;
        _context.Houses.Remove(model);
        _context.SaveChanges();
    }


    public void Delete(HouseModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        Delete(model.Id);
    }
    #endregion
}
