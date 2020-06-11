using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    public interface IMembroRepository : IRepository<Membro>
    {
        Task<Membro> ObterMembro(Guid id);
        Task<IEnumerable<Membro>> ObterTodosMembros();

        List<Membro> ObterMembrosAtivos();
        List<Membro> ObterMembrosInativos();

        Task ExcluirAsync(Guid id);
    }
}
