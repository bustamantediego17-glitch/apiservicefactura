using api.service.factura.application.commons.dtos;
using FluentValidation;

namespace api.service.factura.application.validation;

public sealed class ClienteRequestDtoValidator : AbstractValidator<ClienteRequestDto>
{
    public ClienteRequestDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Direccion)
            .MaximumLength(200);

        RuleFor(x => x.Telefono)
            .MaximumLength(20);
    }
}
