using api.service.factura.application.commons.dtos;
using FluentValidation;

namespace api.service.factura.application.validation;

public sealed class PedidoDetalleRequestDtoValidator : AbstractValidator<PedidoDetalleRequestDto>
{
    public PedidoDetalleRequestDtoValidator()
    {
        RuleFor(x => x.ProductoId)
            .GreaterThan(0);

        RuleFor(x => x.Cantidad)
            .GreaterThan(0);

        RuleFor(x => x.PrecioUnitario)
            .GreaterThan(0);
    }
}
