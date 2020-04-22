using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Models
{
    public class Projeto : Entity
    {
        private string _nome;
        private string _descricao;
        private Cliente _cliente;
        private Servico _servico;
        private decimal _orcamento;
        private readonly List<MembroProjeto> _membros = new List<MembroProjeto>();
        private DateTime _dataContrato;
        private DateTime? _dataInicio;
        private DateTime? _dataConclusao;

        public string Nome
        {
            get => _nome;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Nome é obrigatório.");
                DomainException.When(value.Trim().Length > 100, "O campo Nome não pode conter mais que 100 caracteres.");
                _nome = value.Trim();
            }
        }

        public string Descricao
        {
            get => _descricao;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Descrição é obrigatório.");
                DomainException.When(value.Trim().Length > 1000, "O campo Descrição não pode conter mais que 1000 caracteres.");
                _descricao = value.Trim();
            }
        }

        public Cliente Cliente
        {
            get => _cliente;

            set
            {
                DomainException.When(value == null, "O campo Cliente é obrigatório.");
                _cliente = value;
            }
        }

        public Servico Servico
        {
            get => _servico;

            set
            {
                DomainException.When(value == null, "O campo Serviço é obrigatório.");
                _servico = value;
            }
        }

        public decimal Orcamento
        {
            get => _orcamento;

            set
            {
                DomainException.When(value == 0, "O campo Orçamento é obrigatório.");
                _orcamento = value;
            }
        }

        public ICollection<MembroProjeto> Membros => _membros;

        public void AdicionarMembro(MembroProjeto membroProjeto) => _membros.Add(membroProjeto);

        public DateTime DataContrato
        {
            get => _dataContrato;

            set
            {
                _dataContrato = value;
            }
        }

        public DateTime? DataInicio
        {
            get => _dataInicio;

            set
            {
                _dataInicio = value;
            }
        }

        public DateTime? DataConclusao
        {
            get => _dataConclusao;

            set
            {
                _dataConclusao = value;
            }
        }
    }
}
