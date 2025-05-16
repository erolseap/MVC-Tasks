using ErolNFT.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolNFT.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<CollectionModel> Collections { get; set; }

    public AppDbContext(DbContextOptions opts) : base(opts)
    {
    }
}
