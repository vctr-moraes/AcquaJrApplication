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
            return await Db.Projetos
                .Include(p => p.Membros)
                .Include("Membros.Membro")
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public List<Projeto> ObterProjetos()
        {
            return Db.Projetos
                .Include(p => p.Membros)
                .Include("Membros.Membro")
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .OrderBy(p => p.DataContrato)
                .ToList();
        }

        public List<Projeto> ObterProjetosAtivos()
        {
            return Db.Projetos
                .Where(p => p.DataConclusao == null)
                .OrderBy(p => p.DataContrato)
                .Include(p => p.Membros)
                .Include("Membros.Membro")
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .ToList();
        }

        public List<Projeto> ObterProjetosAtrasados()
        {
            return Db.Projetos
                .Where(p => p.DataPrevista < DateTime.Now && p.DataConclusao == null)
                .OrderBy(p => p.DataContrato)
                .Include(p => p.Membros)
                .Include("Membros.Membro")
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .ToList();
        }

        public List<Projeto> ObterProjetosConcluidos()
        {
            return Db.Projetos
                .Where(p => p.DataConclusao != null)
                .OrderBy(p => p.DataConclusao)
                .Include(p => p.Membros)
                .Include("Membros.Membro")
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .ToList();
        }

        public async Task<Projeto> ObterMembrosProjeto(Guid id)
        {
            return await Db.Projetos
                .Include(p => p.Membros)
                .Include("Membros.Membro")
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SalvarProjeto(Projeto projeto)
        {
            DomainException.When(projeto.Membros.Count() == 0, "O projeto precisa conter, ao menos, um membro participante.");
            await Adicionar(projeto);
        }

        public async Task AtualizarProjeto(Projeto projeto)
        {
            DomainException.When(projeto.Membros.Count() == 0, "O projeto precisa conter, ao menos, um membro participante.");
            await Atualizar(projeto);
        }

        public async Task ExcluirProjeto(Guid id)
        {
            var projeto = await ObterProjeto(id);
            await Remover(projeto.Id);
        }
    }
}
