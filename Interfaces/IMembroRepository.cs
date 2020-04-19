using AcquaJrApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Interfaces
{
    interface IMembroRepository : IRepository<Membro>
    {
        Task<Membro> ObterMembro(Guid id);
        Task<IEnumerable<Membro>> ObterTodosMembros();
    }
}
