using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public List<Evento> ObterEventos()
        {
            return Db.Eventos.Include(e => e.Datas).Include(e => e.Convidados).ToList();
        }
    }
}
