using ErolScholar.DAL.Contexts;
using ErolScholar.DAL.Models;

namespace ErolScholar.BL.Services;

public class UpcomingEventService
{
    protected readonly AppDbContext _context;

    public UpcomingEventService(AppDbContext context)
    {
        _context = context;
    }

    #region Create
    public void Create(UpcomingEvent model)
    {
        _context.UpcomingEvents.Add(model);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public UpcomingEvent? GetById(int id) => _context.UpcomingEvents.Find(id);
    public List<UpcomingEvent> GetAll() => _context.UpcomingEvents.ToList();
    #endregion

    #region Update
    public void Update(int id, UpcomingEvent model)
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
        _context.UpcomingEvents.Remove(model);
        _context.SaveChanges();
    }

    public void Delete(UpcomingEvent model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        Delete(model.Id);
    }
    #endregion
}
