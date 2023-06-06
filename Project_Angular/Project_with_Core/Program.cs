using Microsoft.EntityFrameworkCore;
using Project_with_Core.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PlantDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(options => {
    options.AddPolicy("EnableCORS",
        builder => {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

        });
});
builder.Services.AddControllers()
    .AddNewtonsoftJson(option =>
    {
        option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
        option.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
    });
var app = builder.Build();

app.UseStaticFiles();
app.UseCors("EnableCORS");
app.MapControllers();


app.Run();