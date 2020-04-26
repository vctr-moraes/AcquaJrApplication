using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    interface IServicoRepository : IRepository<Servico>
    {
        Task<Servico> ObterServico(Guid id);
        Task<IEnumerable<Servico>> ObterTodosServicos();
    }
}
