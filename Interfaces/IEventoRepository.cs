using AcquaJrApplication.Models;
using System.Threading.Tasks;

namespace AcquaJrApplication.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task SalvarEvento(Evento evento);
    }
}
