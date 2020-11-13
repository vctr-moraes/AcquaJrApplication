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
            return await Db.Servicos
                .Include(s => s.Projetos)
                .Include("Projetos.Servico")
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public List<Servico> ObterServicosAtivos()
        {
            return Db.Servicos.Where(m => m.Status == true).OrderBy(s => s.Nome).ToList();
        }

        public List<Servico> ObterServicosInativos()
        {
            return Db.Servicos.Where(m => m.Status == false).OrderBy(s => s.Nome).ToList();
        }

        public async Task SalvarServico(Servico servico)
        {
            await Adicionar(servico);
        }

        public async Task AtualizarServico(Servico servico)
        {
            await Atualizar(servico);
        }

        public async Task ExcluirServico(Guid id)
        {
            var servico = await ObterServico(id);
            var projetos = _projetoRepository.ObterProjetos().Where(projetos => projetos.ServicoId == id).ToList();

            DomainException.When(projetos.Count() > 0, "Este serviço não pode ser deletado, pois está vinculado a algum projeto.");
            
            await Remover(servico.Id);
        }
    }
}
