using System;

namespace AcquaJrApplication.Models
{
    public class Convidado : Entity
    {
        private string _nome;
        private string _cidade;
        private string _estado;
        private string _instituicao;
        private string _participacao;
        private Guid _eventoId;

        /* EF Relation */
        private Evento _evento;

        public Convidado() { }

        public Convidado(Evento evento)
        {
            DomainException.When(evento == null, "Um convidado precisa estar vinculado a um evento.");
            Evento = evento;
        }

        public string Nome
        {
            get => _nome;

            set
            {
                DomainException.When(value.Trim().Length > 100, "O campo Nome não pode conter mais que 100 caracteres.");
                _nome = value.Trim();
            }
        }

        public string Cidade
        {
            get => _cidade;

            set
            {
                DomainException.When(value.Trim().Length > 50, "O campo Cidade não pode conter mais que 50 caracteres.");
                _cidade = value.Trim();
            }
        }

        public string Estado
        {
            get => _estado;

            set
            {
                DomainException.When(value?.Trim().Length > 50, "O campo Estado não pode conter mais que 50 caracteres.");
                _estado = value?.Trim();
            }
        }

        public string Instituicao
        {
            get => _instituicao;

            set
            {
                DomainException.When(value.Trim().Length > 200, "O campo Instituição não pode conter mais que 200 caracteres.");
                _instituicao = value.Trim();
            }
        }

        public string Participacao
        {
            get => _participacao;

            set
            {
                DomainException.When(value.Trim().Length > 200, "O campo Participação não pode conter mais que 200 caracteres.");
                _participacao = value.Trim();
            }
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
