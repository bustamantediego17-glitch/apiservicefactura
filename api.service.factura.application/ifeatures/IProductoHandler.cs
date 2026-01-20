using api.service.factura.application.commons.dtos;

namespace api.service.factura.application.ifeatures;

public interface IProductoHandler
{
    Task<List<ProductoResponseDto>> GetAll();
    Task<ProductoResponseDto> GetById(int id);
    Task<ProductoResponseDto> Insert(ProductoRequestDto productoRequest);
}