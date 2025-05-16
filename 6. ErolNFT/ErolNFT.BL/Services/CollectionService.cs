using ErolNFT.DAL.Contexts;
using ErolNFT.DAL.Models;

namespace ErolNFT.BL.Services;

public class CollectionService
{
    protected readonly AppDbContext _context;

    public CollectionService(AppDbContext context)
    {
        _context = context;
    }

    #region Create
    public void Create(CollectionModel model)
    {
        _context.Collections.Add(model);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public CollectionModel? GetById(int id) => _context.Collections.Find(id);
    public List<CollectionModel> GetAll() => _context.Collections.ToList();
    #endregion

    #region Update
    public void Update(int id, CollectionModel model)
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
        _context.Collections.Remove(model);
        _context.SaveChanges();
    }


    public void Delete(CollectionModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        Delete(model.Id);
    }
    #endregion
}
