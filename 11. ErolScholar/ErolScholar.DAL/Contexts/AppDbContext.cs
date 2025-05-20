using ErolScholar.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolScholar.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<UpcomingEvent> UpcomingEvents { get; set; }

    public AppDbContext(DbContextOptions opts) : base(opts)
    {
    }
}
