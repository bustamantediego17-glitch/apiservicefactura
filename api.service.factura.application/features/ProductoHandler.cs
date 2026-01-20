using api.service.factura.application.commons.dtos;
using api.service.factura.application.commons.mappings;
using api.service.factura.application.ifeatures;
using api.service.factura.infrastructure.context.producto;

namespace api.service.factura.application.features;

public class ProductoHandler : IProductoHandler
{ 
    private readonly Mappings _mapper;
    private readonly IProductoContext _context;

    public ProductoHandler(IProductoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<ProductoResponseDto>> GetAll()
    {
        var productos = await _context.GetAllAsync();
        return _mapper.ToResponseDto(productos);
    }

    public async Task<ProductoResponseDto> GetById(int id)
    {
        var producto = await _context.GetByIdAsync(id);
        return _mapper.ToResponseDto(producto);
    }

    public async Task<ProductoResponseDto> Insert(ProductoRequestDto productoRequest)
    {
        var producto = _mapper.ToRequestDto(productoRequest);

        var productoResponse = await _context.InsertAsync(producto);

        return _mapper.ToResponseDto(productoResponse);
    }
}