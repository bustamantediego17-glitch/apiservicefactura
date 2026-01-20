using api.service.factura.application.commons.dtos;
using api.service.factura.application.commons.mappings;
using api.service.factura.application.ifeatures;
using api.service.factura.infrastructure.context.pago;

namespace api.service.factura.application.features;

public class PagoHandler : IPagoHandler
{
    private readonly Mappings _mapper;
    private readonly IPagoContext _context;

    public PagoHandler(IPagoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<PagoResponseDto>> GetAll()
    {
        var pagos = await _context.GetAllAsync();
        return _mapper.ToResponseDto(pagos);
    }

    public async Task<PagoResponseDto> GetById(int id)
    {
        var pago = await _context.GetByIdAsync(id);
        return _mapper.ToResponseDto(pago);
    }

    public async Task<PagoResponseDto> Insert(PagoRequestDto pagoRequest)
    {
        var pago = _mapper.ToRequestDto(pagoRequest);
        var pagoResponse = await _context.InsertAsync(pago);
        return _mapper.ToResponseDto(pagoResponse);
    }
}
