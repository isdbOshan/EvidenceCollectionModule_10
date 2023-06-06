using Microsoft.EntityFrameworkCore;
using R52_M12_Class_01_Work_02.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WorkerDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
