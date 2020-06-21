using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto> ObterProjeto(Guid id);
        List<Projeto> ObterProjetos();
        List<Projeto> ObterProjetosAtivos();
        List<Projeto> ObterProjetosConcluidos();
        Task<Projeto> ObterMembrosProjeto(Guid id);
        Task SalvarProjeto(Projeto projeto);
        Task AtualizarProjeto(Projeto projeto);
        Task ExcluirProjeto(Guid id);
    }
}
