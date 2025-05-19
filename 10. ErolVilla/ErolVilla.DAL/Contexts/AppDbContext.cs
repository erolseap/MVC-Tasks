using ErolVilla.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolVilla.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<HouseModel> Houses { get; set; }

    public AppDbContext(DbContextOptions opts) : base(opts)
    {
    }
}
