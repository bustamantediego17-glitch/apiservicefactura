using api.service.factura.application.commons.dtos;
using FluentValidation;

namespace api.service.factura.application.validation;

public sealed class CategoriaRequestDtoValidator : AbstractValidator<CategoriaRequestDto>
{
    public CategoriaRequestDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .MaximumLength(80);
    }
}
