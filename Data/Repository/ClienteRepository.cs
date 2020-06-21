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
            return await Db.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public List<Cliente> ObterClientes()
        {
            return Db.Clientes.AsNoTracking().OrderBy(c => c.NomeFantasia).ToList();
        }

        public async Task SalvarCliente(Cliente cliente)
        {
            await Adicionar(cliente);
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            await Atualizar(cliente);
        }

        public async Task ExcluirCliente(Guid id)
        {
            var cliente = await ObterCliente(id);
            var projetos = _projetoRepository.ObterProjetos().Where(p => p.ClienteId == id).ToList();

            if (projetos.Count() > 0)
            {
                DomainException.When(true, "Este cliente não pode ser deletado, pois está vinculado a algum projeto.");
            }
            
            await Remover(cliente.Id);
        }
    }
}
