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

        public List<Projeto> ObterProjetos()
        {
            return Db.Projetos.AsNoTracking()
                .Include(p => p.Membros)
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .OrderBy(p => p.DataContrato)
                .ToList();
        }

        public List<Projeto> ObterProjetosAtivos()
        {
            return Db.Projetos.AsNoTracking().Where(p => p.DataConclusao == null).OrderBy(p => p.DataContrato).ToList();
        }

        public List<Projeto> ObterProjetosAtrasados()
        {
            return Db.Projetos.AsNoTracking().Where(p => p.DataConclusao == DateTime.Now).OrderBy(p => p.DataContrato).ToList();
        }

        public List<Projeto> ObterProjetosConcluidos()
        {
            return Db.Projetos.AsNoTracking().Where(p => p.DataConclusao != null).OrderBy(p => p.DataConclusao).ToList();
        }

        public async Task<Projeto> ObterMembrosProjeto(Guid id)
        {
            return await Db.Projetos.AsNoTracking()
                .Include(p => p.Membros)
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SalvarProjeto(Projeto projeto)
        {
            await Adicionar(projeto);
        }

        public async Task AtualizarProjeto(Projeto projeto)
        {
            await Atualizar(projeto);
        }

        public async Task ExcluirProjeto(Guid id)
        {
            var projeto = await ObterProjeto(id);
            await Remover(projeto.Id);
        }
    }
}
