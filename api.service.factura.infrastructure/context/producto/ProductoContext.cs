using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.producto;

public class ProductoContext : IProductoContext
{
    private readonly IContextGeneral<Producto> _context;

    public ProductoContext(IContextGeneral<Producto> context)
    {
        _context = context;
    }

    public async Task<List<Producto>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Producto> GetByIdAsync(int id)
    {
        Producto producto = await _context.GetById(id) ?? new Producto();
        return producto;
    }

    public async Task<Producto> InsertAsync(Producto producto)
    {
        return await _context.Add(producto);
    }
}