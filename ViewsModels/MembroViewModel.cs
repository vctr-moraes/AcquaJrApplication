using System;
using System.ComponentModel.DataAnnotations;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.ViewsModels
{
    public class MembroViewModel
    {
        public MembroViewModel() { }

        public MembroViewModel(Membro membro)
        {
            Id = membro.Id;
            Nome = membro.Nome;
            Cpf = membro.Cpf;
            DataNascimento = membro.DataNascimento;
            Logradouro = membro.Logradouro;
            Bairro = membro.Bairro;
            Cidade = membro.Cidade;
            Cep = membro.Cep;
            Estado = membro.Estado;
            Email = membro.Email;
            Telefone = membro.Telefone;
            TemSeguro = membro.TemSeguro;
            TemCnh = membro.TemCnh;
            Curso = membro.Curso;
            MatriculaAcademica = membro.MatriculaAcademica;
            Cargo = membro.Cargo;
            DataEntrada = membro.DataEntrada;
            DataSaida = membro.DataSaida;
            Status = membro.Status;
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cidade { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cep { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Estado { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Telefone { get; set; }

        [Display(Name = "Possui seguro de vida?")]
        public bool TemSeguro { get; set; }

        [Display(Name = "Possui CNH?")]
        public bool TemCnh { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Curso Curso { get; set; }

        [Display(Name = "Matrícula Acadêmica")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string MatriculaAcademica { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Cargo Cargo { get; set; }

        [Display(Name = "Data de Entrada")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime? DataEntrada { get; set; }

        [Display(Name = "Data de Saída")]
        [DataType(DataType.Date)]
        public DateTime? DataSaida { get; set; }

        [Display(Name = "Membro Ativo?")]
        public bool Status { get; set; } = true;
    }
}
