using AcquaJrApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcquaJrApplication.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task SalvarEvento(Evento evento);
        List<Evento> ObterEventos();
    }
}
