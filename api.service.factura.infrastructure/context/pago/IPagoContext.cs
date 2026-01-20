using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.pago;

public interface IPagoContext
{
    Task<List<Pago>> GetAllAsync();
    Task<Pago> GetByIdAsync(int id);
    Task<Pago> InsertAsync(Pago pago);
}
