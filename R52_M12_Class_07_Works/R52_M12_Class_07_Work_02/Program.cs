using BookEvidences.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using R52_M12_Class_07_Work_02.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PublisherDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("identity")));
#region Identy Configurations
builder.Services.AddIdentity<IdentityUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
#endregion

#region Authentication/JWT Configuration
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options => {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["Jwt:Site"],
            ValidIssuer = builder.Configuration["Jwt:Site"],
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"] ?? ""))
        };
    });
#endregion
builder.Services.AddControllersWithViews().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
    op.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
});
builder.Services.AddCors(op => {
    op.AddPolicy("EnableCORS", builder => {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseStaticFiles();
app.UseCors("EnableCORS");
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
