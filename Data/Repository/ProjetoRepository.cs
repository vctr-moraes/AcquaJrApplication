using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Data.Repository
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Projeto> ObterProjeto(Guid id)
        {
            return await Db.Projetos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Projeto>> ObterTodosProjetos()
        {
            return await Db.Projetos.AsNoTracking().OrderBy(p => p.Nome).ToListAsync();
        }

        public List<Projeto> ObterProjetos()
        {
            return Db.Projetos.AsNoTracking().OrderBy(p => p.DataContrato).ToList();
        }

        public List<Projeto> ObterProjetosAtivos()
        {
            return Db.Projetos.AsNoTracking().Where(p => p.DataConclusao == null).OrderBy(p => p.DataContrato).ToList();
        }

        public List<Projeto> ObterProjetosConcluidos()
        {
            return Db.Projetos.AsNoTracking().Where(p => p.DataConclusao != null).OrderBy(p => p.DataConclusao).ToList();
        }
    }
}
