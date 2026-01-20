using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.producto;

public interface IProductoContext
{
    Task<List<Producto>> GetAllAsync();

    Task<Producto> GetByIdAsync(int id);

    Task<Producto> InsertAsync(Producto producto);
}