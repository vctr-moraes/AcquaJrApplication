using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto> ObterProjeto(Guid id);
        Task<IEnumerable<Projeto>> ObterTodosProjetos();
    }
}
