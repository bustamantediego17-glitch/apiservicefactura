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

    public async Task<Pago?> GetByIdAsync(int id)
    {
        return await _context.GetById(id);
    }

    public async Task<Pago> InsertAsync(Pago pago)
    {
        return await _context.Add(pago);
    }

    public async Task<Pago?> UpdateAsync(int id, Pago pago)
    {
        var pagoToUpdate = await _context.GetById(id);
        if (pagoToUpdate != null)
        {
            pagoToUpdate.Metodo = pago.Metodo;
            pagoToUpdate.Monto = pago.Monto;
            await _context.Update(pagoToUpdate);
            return pagoToUpdate;
        }
        return null;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var pagoToDelete = await _context.GetById(id);
        if (pagoToDelete != null)
        {
            await _context.Delete(pagoToDelete);
            return 1;
        }
        return 0;
    }
}
