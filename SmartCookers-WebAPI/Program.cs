using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartCookers_WebAPI.Data;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Data.Repository;
using SmartCookers_WebAPI.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<SmartDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.RegisterIdentity();
builder.Services.RegisterDependancyInjection();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
      //  ValidAudience = configuration["JWT:ValidAudience"],
        //ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

//extension method 
public static class ServiceExtensions
{
    public static void RegisterIdentity(this IServiceCollection Services)
    {
        // For Identity
        Services.AddIdentity<SmartUser, SmartIdentityRole>()
             .AddEntityFrameworkStores<SmartDbContext>()
             .AddDefaultTokenProviders();

    }
    //for dependancy injection
    public static void RegisterDependancyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProductRepo, ProductRepo>();
        services.AddScoped<IOutletRepo, OutletRepo>();
    }

}