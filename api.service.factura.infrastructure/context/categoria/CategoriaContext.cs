using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.categoria;

public class CategoriaContext : ICategoriaContext
{
    private readonly IContextGeneral<Categoria> _context;

    public CategoriaContext(IContextGeneral<Categoria> context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Categoria> GetByIdAsync(int id)
    {
        Categoria categoria = await _context.GetById(id) ?? new Categoria();
        return categoria;
    }

    public async Task<Categoria> InsertAsync(Categoria categoria)
    {
        return await _context.Add(categoria);
    }
}