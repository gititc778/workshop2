using Microsoft.AspNetCore.Mvc;
using TireShop.Services;
using TireShop.Models;
using TireShop.DTOs;
using FluentValidation;

namespace TireShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TireController : ControllerBase
{
    private readonly TireService _service;
    private readonly IValidator<TireDto> _validator;

    public TireController(TireService service, IValidator<TireDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Post(TireDto dto)
    {
        var validation = _validator.Validate(dto);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        var tire = new Tire
        {
            Brand = dto.Brand,
            Size = dto.Size,
            Price = dto.Price
        };

        return Ok(_service.Add(tire));
    }
}
