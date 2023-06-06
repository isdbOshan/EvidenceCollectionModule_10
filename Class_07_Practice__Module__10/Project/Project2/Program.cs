using Microsoft.EntityFrameworkCore;
using Project2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PlantDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(op =>
{
    op.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
    op.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseCors("EnableCors");
app.MapControllers();

app.Run();
