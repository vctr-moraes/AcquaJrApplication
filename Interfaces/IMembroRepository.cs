using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Interfaces
{
    interface IMembroRepository : IRepository<Membro>
    {
        Task<Membro> ObterMembro(Guid id);
        Task<IEnumerable<Membro>> ObterTodosMembros();
    }
}
