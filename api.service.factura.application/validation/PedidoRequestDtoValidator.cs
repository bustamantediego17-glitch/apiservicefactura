using api.service.factura.application.commons.dtos;
using FluentValidation;

namespace api.service.factura.application.validation;

public sealed class PedidoRequestDtoValidator : AbstractValidator<PedidoRequestDto>
{
    public PedidoRequestDtoValidator()
    {
        RuleFor(x => x.ClienteId)
            .GreaterThan(0);

        RuleFor(x => x.PedidoDetalles)
            .NotNull()
            .NotEmpty();

        RuleForEach(x => x.PedidoDetalles)
            .SetValidator(new PedidoDetalleRequestDtoValidator());
    }
}
