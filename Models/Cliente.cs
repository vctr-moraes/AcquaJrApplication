using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Models
{
    public class Cliente : Entity
    {
        private TipoPessoa _tipoPessoa;
        private string _nomeFantasia;
        private string _razaoSocial;
        private string _cpf;
        private string _cnpj;
        private string _inscricaoEstadual;
        private string _rgCtps;
        private string _logradouro;
        private string _pontoReferencia;
        private string _bairro;
        private string _cidade;
        private string _cep;
        private string _estado;
        private string _email;
        private string _telefone1;
        private string _telefone2;
        private string _observacoes;
        private DateTime? _dataCadastro;

        /* EF Relation */
        private Projeto _projeto;

        public TipoPessoa TipoPessoa
        {
            get => _tipoPessoa;

            set
            {
                DomainException.When(!Enum.IsDefined(typeof(TipoPessoa), value), "O campo Tipo Pessoa é obrigatório.");
                _tipoPessoa = value;
            }
        }

        public string NomeFantasia
        {
            get => _nomeFantasia;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Nome Fantasia é obrigatório.");
                DomainException.When(value.Trim().Length > 100, "O campo Nome Fantasia não pode conter mais que 100 caracteres.");
                _nomeFantasia = value.Trim();
            }
        }

        public string RazaoSocial
        {
            get => _razaoSocial;

            set
            {
                DomainException.When(value?.Trim().Length > 150, "O campo Razão Social não pode conter mais que 150 caracteres.");
                _razaoSocial = value?.Trim();
            }
        }

        public string Cpf
        {
            get => _cpf;

            set
            {
                DomainException.When(value?.Trim().Length > 20, "O campo CPF não pode conter mais que 11 caracteres.");
                _cpf = value?.Trim();
            }
        }

        public string Cnpj
        {
            get => _cnpj;

            set
            {
                DomainException.When(value?.Trim().Length > 20, "O campo CNPJ não pode conter mais que 14 caracteres.");
                _cnpj = value?.Trim();
            }
        }

        public string InscricaoEstadual
        {
            get => _inscricaoEstadual;

            set
            {
                DomainException.When(value?.Trim().Length > 20, "O campo Inscrição Estadual não pode conter mais que 20 caracteres.");
                _inscricaoEstadual = value?.Trim();
            }
        }

        public string RgCtps
        {
            get => _rgCtps;

            set
            {
                DomainException.When(value?.Trim().Length > 20, "O campo RG/CTPS não pode conter mais que 20 caracteres.");
                _rgCtps = value?.Trim();
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

        public string Email
        {
            get => _email;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo E-mail é obrigatório.");
                DomainException.When(value.Trim().Length > 100, "O campo E-mail não pode conter mais que 100 caracteres.");
                _email = value.Trim();
            }
        }

        public string Telefone1
        {
            get => _telefone1;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Telefone é obrigatório.");
                DomainException.When(value.Trim().Length > 20, "O campo Telefone não pode conter mais que 11 caracteres.");
                _telefone1 = value.Trim();
            }
        }

        public string Telefone2
        {
            get => _telefone2;

            set
            {
                DomainException.When(value?.Trim().Length > 20, "O campo Telefone Adicional não pode conter mais que 11 caracteres.");
                _telefone2 = value?.Trim();
            }
        }

        public string Observacoes
        {
            get => _observacoes;

            set
            {
                DomainException.When(value?.Trim().Length > 500, "O campo Observações não pode conter mais que 500 caracteres.");
                _observacoes = value?.Trim();
            }
        }

        public DateTime? DataCadastro
        {
            get => _dataCadastro;

            set
            {
                _dataCadastro = value;
            }
        }

        public Projeto Projeto
        {
            get => _projeto;

            set => _projeto = value;
        }
    }
}
