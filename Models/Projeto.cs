using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Models
{
    public class Projeto : Entity
    {
        private Guid _clienteId;
        private Guid _servicoId;
        private string _nome;
        private string _descricao;
        private decimal _orcamento;
        private DateTime _dataContrato;
        private DateTime? _dataInicio;
        private DateTime? _dataConclusao;

        /* EF Relations */
        private Cliente _cliente;
        private Servico _servico;
        private readonly List<MembroProjeto> _membros = new List<MembroProjeto>();

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
                DomainException.When(value == null, "É necessário selecionar um Cliente.");
                _cliente = value;
            }
        }

        public Guid ClienteId
        {
            get => _clienteId;

            set => _clienteId = value;
        }

        public Servico Servico
        {
            get => _servico;

            set
            {
                DomainException.When(value == null, "É necessário selecionar um Serviço.");
                _servico = value;
            }
        }

        public Guid ServicoId
        {
            get => _servicoId;

            set => _servicoId = value;
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
