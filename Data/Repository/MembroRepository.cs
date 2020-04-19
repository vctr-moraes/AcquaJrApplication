using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Data.Repository
{
    public class MembroRepository : Repository<Membro>, IMembroRepository
    {
        public MembroRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Membro> ObterMembro(Guid id)
        {
            return await Db.Membros.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Membro>> ObterTodosMembros()
        {
            return await Db.Membros.AsNoTracking()
                .OrderBy(m => m.Nome)
                .ToListAsync();
        }
    }
}
