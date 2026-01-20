using api.service.factura.application.commons.dtos;

namespace api.service.factura.application.ifeatures;

public interface IPagoHandler
{
    Task<List<PagoResponseDto>> GetAll();
    Task<PagoResponseDto?> GetById(int id);
    Task<PagoResponseDto> Insert(PagoRequestDto pagoRequest);
    Task<PagoResponseDto?> Update(int id, PagoRequestDto pagoRequest);
    Task<int> Delete(int id);
}
