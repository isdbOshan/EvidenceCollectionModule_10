using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarPartsDetailDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();