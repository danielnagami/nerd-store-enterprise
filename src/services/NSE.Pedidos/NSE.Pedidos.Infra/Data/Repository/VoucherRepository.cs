using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Vouchers;
using System.Threading.Tasks;

namespace NSE.Pedidos.Infra.Repository.Data
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Voucher> ObetrVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }
    }
}