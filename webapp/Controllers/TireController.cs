using Microsoft.AspNetCore.Mvc;
using TireShopWeb.Services;
using TireShopWeb.Models;
using FluentValidation;

namespace TireShopWeb.Controllers;

public class TireController : Controller
{
    private readonly TireService _service;
    private readonly IValidator<Tire> _validator;

    public TireController(TireService service, IValidator<Tire> validator)
    {
        _service = service;
        _validator = validator;
    }

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Tire tire)
    {
        var result = _validator.Validate(tire);
        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.ErrorMessage);

            return View(tire);
        }

        _service.Add(tire);
        return RedirectToAction("Index");
    }
}
