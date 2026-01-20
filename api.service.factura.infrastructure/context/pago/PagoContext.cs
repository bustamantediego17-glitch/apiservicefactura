using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.pago;

public class PagoContext : IPagoContext
{
    private readonly IContextGeneral<Pago> _context;

    public PagoContext(IContextGeneral<Pago> context)
    {
        _context = context;
    }

    public async Task<List<Pago>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Pago> GetByIdAsync(int id)
    {
        Pago pago = await _context.GetById(id) ?? new Pago();
        return pago;
    }

    public async Task<Pago> InsertAsync(Pago pago)
    {
        return await _context.Add(pago);
    }
}