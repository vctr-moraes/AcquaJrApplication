using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;

namespace AcquaJrApplication.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Servico> ObterServico(Guid id)
        {
            return await Db.Servicos.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Servico>> ObterTodosServicos()
        {
            return await Db.Servicos.AsNoTracking()
                .OrderBy(s => s.Nome)
                .ToListAsync();
        }
    }
}
