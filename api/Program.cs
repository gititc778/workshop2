using Microsoft.EntityFrameworkCore;
using TireShop.Data;
using TireShop.Services;
using FluentValidation;
using TireShop.DTOs;
using TireShop.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TireDb"));

builder.Services.AddScoped<TireService>();
builder.Services.AddScoped<IValidator<TireDto>, TireValidator>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
