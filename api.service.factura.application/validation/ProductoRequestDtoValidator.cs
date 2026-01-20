using api.service.factura.application.commons.dtos;
using FluentValidation;

namespace api.service.factura.application.validation;

public sealed class ProductoRequestDtoValidator : AbstractValidator<ProductoRequestDto>
{
    public ProductoRequestDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Precio)
            .GreaterThan(0);

        RuleFor(x => x.CategoriaId)
            .GreaterThan(0);
    }
}
