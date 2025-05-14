using ErolCharityNTIER.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolCharityNTIER.DAL.Contexts;

public class AppDbContext : DbContext
{
    private const string HOST_NAME = @"DESKTOP-GTVND9D\SQLEXPRESS";
    private const string DATABASE_NAME = "CharityDB";

    private const string _connectionInfo = $"Server={HOST_NAME};Database={DATABASE_NAME};Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<Cause> Causes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionInfo);
        base.OnConfiguring(optionsBuilder);
    }
}
