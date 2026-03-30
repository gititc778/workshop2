using Microsoft.EntityFrameworkCore;
using TireShopWeb.Data;
using TireShopWeb.Services;
using FluentValidation;
using TireShopWeb.Models;
using TireShopWeb.Validators;
using AutoMapper;
using TireShopWeb.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// EF
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TireDb"));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// DI Service
builder.Services.AddScoped<TireService>();

// FluentValidation
builder.Services.AddScoped<IValidator<Tire>, TireValidator>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tire}/{action=Index}/{id?}");


app.Urls.Clear();
app.Urls.Add("http://0.0.0.0:5000");


app.Run();