using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;

namespace AcquaJrApplication.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Cliente> ObterCliente(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await Db.Clientes.AsNoTracking()
                .OrderBy(c => c.NomeFantasia)
                .ToListAsync();
        }
    }
}
