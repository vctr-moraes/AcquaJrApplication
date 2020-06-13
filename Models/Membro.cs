using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Models
{
    public class Membro : Entity
    {
        private string _nome;
        private string _cpf;
        private DateTime? _dataNascimento;
        private string _logradouro;
        private string _bairro;
        private string _cidade;
        private string _cep;
        private string _estado;
        private string _email;
        private string _telefone;
        private bool _temSeguro;
        private bool _temCnh;
        private Curso _curso;
        private string _matriculaAcademica;
        private Cargo _cargo;
        private DateTime? _dataEntrada;
        private DateTime? _dataSaida;
        private bool _status;

        /* EF Relation */
        private readonly List<Projeto> _projetos = new List<Projeto>();

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

        public string Cpf
        {
            get => _cpf;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo CPF é obrigatório.");
                DomainException.When(value.Trim().Length > 20, "O campo CPF não pode conter mais que 11 caracteres.");
                _cpf = value.Trim();
            }
        }

        public DateTime? DataNascimento
        {
            get => _dataNascimento;
            set => _dataNascimento = value;
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

        public string Telefone
        {
            get => _telefone;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Telefone é obrigatório.");
                DomainException.When(value.Trim().Length > 20, "O campo Telefone não pode conter mais que 11 caracteres.");
                _telefone = value.Trim();
            }
        }

        public bool TemSeguro
        {
            get => _temSeguro;
            set => _temSeguro = value;
        }

        public bool TemCnh
        {
            get => _temCnh;
            set => _temCnh = value;
        }

        public Curso Curso
        {
            get => _curso;

            set
            {
                DomainException.When(!Enum.IsDefined(typeof(Curso), value), "O campo Curso é obrigatório.");
                _curso = value;
            }
        }

        public string MatriculaAcademica
        {
            get => _matriculaAcademica;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Matrícula Acadêmica é obrigatório.");
                DomainException.When(value.Trim().Length > 20, "O campo Matrícula Acadêmica não pode conter mais que 20 caracteres.");
                _matriculaAcademica = value.Trim();
            }
        }

        public Cargo Cargo
        {
            get => _cargo;

            set
            {
                DomainException.When(!Enum.IsDefined(typeof(Cargo), value), "O campo Cargo é obrigatório.");
                _cargo = value;
            }
        }

        public DateTime? DataEntrada
        {
            get => _dataEntrada;
            set => _dataEntrada = value;
        }

        public DateTime? DataSaida
        {
            get => _dataSaida;
            set => _dataSaida = value;
        }

        public bool Status
        {
            get => _status;
            set => _status = value;
        }

        public ICollection<Projeto> Projetos => _projetos;
    }
}
