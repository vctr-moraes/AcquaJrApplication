using System;

namespace AcquaJrApplication.Models
{
    public class DataEvento : Entity
    {
        private DateTime _data;
        private TimeSpan _horaInicio;
        private TimeSpan _horaEncerramento;
        private Guid _eventoId;

        /* EF Relation */
        private Evento _evento;

        private DataEvento() { }

        public DataEvento(Evento evento)
        {
            DomainException.When(evento == null, "Uma data de evento precisa estar vinculada a um evento.");
            Evento = evento;
        }

        public DateTime Data
        {
            get => _data;
            set => _data = value;
        }

        public TimeSpan HoraInicio
        {
            get => _horaInicio;
            set => _horaInicio = value;
        }

        public TimeSpan HoraEncerramento
        {
            get => _horaEncerramento;
            set => _horaEncerramento = value;
        }

        public Guid EventoId
        {
            get => _eventoId;
            set => _eventoId = value;
        }

        public Evento Evento
        {
            get => _evento;
            set => _evento = Evento;
        }
    }
}
