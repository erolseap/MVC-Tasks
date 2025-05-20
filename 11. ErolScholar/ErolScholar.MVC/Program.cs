using ErolScholar.DAL.Contexts;
using ErolScholar.BL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ErolScholar.DAL.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(ctx => ctx.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddIdentity<UserModel, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<UpcomingEventService>();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{Controller=Home}/{Action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}"
);

app.Run();
