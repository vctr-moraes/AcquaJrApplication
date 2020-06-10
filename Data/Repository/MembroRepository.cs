using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;

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

        public List<Membro> ObterMembrosAtivos()
        {
            return Db.Membros.AsNoTracking()
                .Where(m => m.Status == true)
                .OrderBy(m => m.Nome)
                .ToList();
        }

        public List<Membro> ObterMembrosInativos()
        {
            return Db.Membros.AsNoTracking()
                .Where(m => m.Status == false)
                .OrderBy(m => m.Nome)
                .ToList();
        }
    }
}
