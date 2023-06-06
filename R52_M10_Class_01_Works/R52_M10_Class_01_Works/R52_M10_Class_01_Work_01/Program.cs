using Microsoft.EntityFrameworkCore;
using R52_M10_Class_01_Work_01.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(options => {
    options.AddPolicy("EnableCORS",
        builder => {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

        });
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseCors("EnableCORS");
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
