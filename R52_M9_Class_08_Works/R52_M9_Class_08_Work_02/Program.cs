using Microsoft.EntityFrameworkCore;
using R52_M9_Class_08_Work_02.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
