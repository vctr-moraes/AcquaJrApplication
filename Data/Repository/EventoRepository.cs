using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoRepository(ApplicationDbContext context, IEventoRepository eventoRepository) : base(context)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task SalvarEvento(Evento evento)
        {
            await Adicionar(evento);
        }
    }
}
