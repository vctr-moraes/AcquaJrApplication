using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;
using System.Threading.Tasks;

namespace AcquaJrApplication.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(ApplicationDbContext context) : base(context) { }

        public async Task SalvarEvento(Evento evento)
        {
            await Adicionar(evento);
        }
    }
}
