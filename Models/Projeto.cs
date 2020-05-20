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
        private decimal? _custoMaoDeObra;
        private decimal? _custoProjeto;
        private decimal? _custoInsumos;
        private decimal? _orcamento;
        private string? _logradouro;
        private string? _pontoReferencia;
        private string? _bairro;
        private string? _cidade;
        private string? _cep;
        private string? _estado;
        private DateTime _dataContrato;
        private DateTime? _dataPrevista;
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
                DomainException.When(value.Trim().Length > 150, "O campo Nome não pode conter mais que 150 caracteres.");
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

        public decimal? CustoMaoDeObra
        {
            get => _custoMaoDeObra;

            set
            {
                _custoMaoDeObra = value;
            }
        }

        public decimal? CustoProjeto
        {
            get => _custoProjeto;

            set
            {
                _custoProjeto = value;
            }
        }

        public decimal? CustoInsumos
        {
            get => _custoInsumos;

            set
            {
                _custoInsumos = value;
            }
        }

        public decimal? Orcamento
        {
            get => _orcamento;

            set
            {
                _orcamento = value;
            }
        }

        public string Logradouro
        {
            get => _logradouro;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Logradouro é obrigatório.");
                DomainException.When(value.Trim().Length > 150, "O campo Logradouro não pode conter mais que 150 caracteres.");
                _logradouro = value.Trim();
            }
        }

        public string PontoReferencia
        {
            get => _pontoReferencia;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Ponto de Referencia é obrigatório.");
                DomainException.When(value.Trim().Length > 200, "O campo Ponto de Referencia não pode conter mais que 200 caracteres.");
                _pontoReferencia = value.Trim();
            }
        }

        public string Bairro
        {
            get => _bairro;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Bairro é obrigatório.");
                DomainException.When(value.Trim().Length > 100, "O campo Bairro não pode conter mais que 100 caracteres.");
                _bairro = value.Trim();
            }
        }

        public string Cidade
        {
            get => _cidade;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Cidade é obrigatório.");
                DomainException.When(value.Trim().Length > 50, "O campo Cidade não pode conter mais que 50 caracteres.");
                _cidade = value.Trim();
            }
        }

        public string Cep
        {
            get => _cep;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo CEP é obrigatório.");
                DomainException.When(value.Trim().Length > 20, "O campo CEP não pode conter mais que 8 caracteres.");
                _cep = value.Trim();
            }
        }

        public string Estado
        {
            get => _estado;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Estado é obrigatório.");
                _estado = value.Trim();
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

        public ICollection<MembroProjeto> Membros => _membros;

        public void AdicionarMembro(MembroProjeto membroProjeto) => _membros.Add(membroProjeto);

        public DateTime DataContrato
        {
            get => _dataContrato;
            set => _dataContrato = value;
        }

        public DateTime? DataPrevista
        {
            get => _dataPrevista;
            set => _dataPrevista = value;
        }

        public DateTime? DataInicio
        {
            get => _dataInicio;
            set => _dataInicio = value;
        }

        public DateTime? DataConclusao
        {
            get => _dataConclusao;
            set => _dataConclusao = value;
        }
    }
}
