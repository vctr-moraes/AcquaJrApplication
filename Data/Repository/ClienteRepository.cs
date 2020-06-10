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
        private readonly IProjetoRepository _projetoRepository;

        public ClienteRepository(ApplicationDbContext context, IProjetoRepository projetoRepository) : base(context)
        {
            _projetoRepository = projetoRepository;
        }

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

        public async Task ExcluirAsync(Guid id)
        {
            var cliente = await ObterCliente(id);

            //var projetos = _projetoRepository.ObterProjetos().Where(p => p.ClienteId == id);
            //var projeto = _projetoRepository.ObterProjeto(); 
            
            //DomainException.When(true, "Este Cliente não pode ser excluído, pois está vinculado a algum Projeto.");

            await Remover(cliente.Id);
        }
    }
}
