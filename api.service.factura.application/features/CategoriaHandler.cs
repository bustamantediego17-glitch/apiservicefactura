using api.service.factura.application.commons.dtos;
using api.service.factura.application.commons.mappings;
using api.service.factura.application.ifeatures;
using api.service.factura.infrastructure.context.categoria;

namespace api.service.factura.application.features;

public class CategoriaHandler : ICategoriaHandler
{
    private readonly Mappings _mapper;
    private readonly ICategoriaContext _context;

    public CategoriaHandler(ICategoriaContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<CategoriaResponseDto>> GetAll()
    {
        var categorias = await _context.GetAllAsync();
        return _mapper.ToResponseDto(categorias);
    }

    public async Task<CategoriaResponseDto> GetById(int id)
    {
        var categoria = await _context.GetByIdAsync(id);
        return _mapper.ToResponseDto(categoria);
    }

    public async Task<CategoriaResponseDto> Insert(CategoriaRequestDto categoriaRequest)
    {
        var categoria = _mapper.ToRequestDto(categoriaRequest);
        var categoriaResponse = await _context.InsertAsync(categoria);
        return _mapper.ToResponseDto(categoriaResponse);
    }
}
