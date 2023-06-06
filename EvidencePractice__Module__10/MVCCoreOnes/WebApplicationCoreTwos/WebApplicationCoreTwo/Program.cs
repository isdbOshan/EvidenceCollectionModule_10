using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContactDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
