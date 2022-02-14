using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCookers_WebAPI.Data;
using SmartCookers_WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<SmartDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.RegisterIdentity();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

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

}