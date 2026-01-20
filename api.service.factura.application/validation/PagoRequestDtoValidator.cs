using api.service.factura.application.commons.dtos;
using FluentValidation;

namespace api.service.factura.application.validation;

public sealed class PagoRequestDtoValidator : AbstractValidator<PagoRequestDto>
{
    public PagoRequestDtoValidator()
    {
        RuleFor(x => x.PedidoId)
            .GreaterThan(0);

        RuleFor(x => x.Metodo)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Monto)
            .GreaterThan(0);
    }
}
