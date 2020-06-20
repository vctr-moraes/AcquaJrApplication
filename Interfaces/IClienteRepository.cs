using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterCliente(Guid id);
        Task<IEnumerable<Cliente>> ObterTodosClientes();

        List<Cliente> ObterClientes();
        Task SalvarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task ExcluirCliente(Guid id);
    }
}
