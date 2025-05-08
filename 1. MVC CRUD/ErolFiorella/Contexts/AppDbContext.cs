using ErolFiorella.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolFiorella.Contexts;

public class AppDbContext : DbContext
{
    protected readonly string _connectionInfo = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=NewFiorellaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<FlowerEntry> FlowerEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionInfo);
        base.OnConfiguring(optionsBuilder);
    }
}
