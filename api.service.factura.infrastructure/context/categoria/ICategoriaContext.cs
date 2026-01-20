using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.categoria;

public interface ICategoriaContext
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria> GetByIdAsync(int id);
    Task<Categoria> InsertAsync(Categoria categoria);
}
