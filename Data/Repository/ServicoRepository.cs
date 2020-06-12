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
        private readonly IProjetoRepository _projetoRepository;

        public ServicoRepository(ApplicationDbContext context, IProjetoRepository projetoRepository) : base(context)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<Servico> ObterServico(Guid id)
        {
            return await Db.Servicos.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Servico>> ObterTodosServicos()
        {
            return await Db.Servicos.AsNoTracking().OrderBy(s => s.Nome).ToListAsync();
        }

        public List<Servico> ObterServicos()
        {
            return Db.Servicos.AsNoTracking().OrderBy(s => s.Nome).ToList();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var servico = await ObterServico(id);
            var projetos = _projetoRepository.ObterProjetos().Where(projetos => projetos.ServicoId == id).ToList();

            if (projetos.Count() > 0)
            {
                DomainException.When(true, "Este serviço não pode ser deletado, pois está vinculado a algum projeto.");
            }
            
            await Remover(servico.Id);
        }
    }
}
