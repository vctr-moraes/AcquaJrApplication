﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        Task<Servico> ObterServico(Guid id);
        Task<List<Servico>> ObterTodosServicos();

        List<Servico> ObterServicos();
        Task SalvarServico(Servico servico);
        Task AtualizarServico(Servico servico);
        Task ExcluirServico(Guid id);
    }
}
