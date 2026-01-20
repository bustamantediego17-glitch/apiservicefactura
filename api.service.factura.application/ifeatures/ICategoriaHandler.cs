using api.service.factura.application.commons.dtos;

namespace api.service.factura.application.ifeatures;

public interface ICategoriaHandler
{
    Task<List<CategoriaResponseDto>> GetAll();
    Task<CategoriaResponseDto> GetById(int id);
    Task<CategoriaResponseDto> Insert(CategoriaRequestDto categoriaRequest);
}
