using FluentValidation;
using TireShop.DTOs;

namespace TireShop.Validators;

public class TireValidator : AbstractValidator<TireDto>
{
    public TireValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Size).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
