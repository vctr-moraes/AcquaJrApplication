using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        Task<Servico> ObterServico(Guid id);
        List<Servico> ObterServicosAtivos();
        List<Servico> ObterServicosInativos();
        Task SalvarServico(Servico servico);
        Task AtualizarServico(Servico servico);
        Task ExcluirServico(Guid id);
    }
}
