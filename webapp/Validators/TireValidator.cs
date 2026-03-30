using FluentValidation;
using TireShopWeb.Models;

namespace TireShopWeb.Validators;

public class TireValidator : AbstractValidator<Tire>
{
    public TireValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Size).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
