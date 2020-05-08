using System;
using System.ComponentModel.DataAnnotations;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.ViewsModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel() { }

        public ClienteViewModel(Cliente cliente)
        {
            Id = cliente.Id;
            TipoPessoa = cliente.TipoPessoa;
            NomeFantasia = cliente.NomeFantasia;
            RazaoSocial = cliente.RazaoSocial;
            Cpf = cliente.Cpf;
            Cnpj = cliente.Cnpj;
            InscricaoEstadual = cliente.InscricaoEstadual;
            RgCtps = cliente.RgCtps;
            Logradouro = cliente.Logradouro;
            PontoReferencia = cliente.PontoReferencia;
            Bairro = cliente.Bairro;
            Cidade = cliente.Cidade;
            Cep = cliente.Cep;
            Estado = cliente.Estado;
            Email = cliente.Email;
            Telefone1 = cliente.Telefone1;
            Telefone2 = cliente.Telefone2;
            Observacoes = cliente.Observacoes;
            DataCadastro = cliente.DataCadastro.ToShortDateString();
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Tipo de Empresa")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public TipoPessoa TipoPessoa { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Razão Social")]
        [MaxLength(150, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string RazaoSocial { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(11, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cpf { get; set; }

        [Display(Name = "CNPJ")]
        [MaxLength(14, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [MaxLength(20, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "RG/CTPS")]
        [MaxLength(20, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string RgCtps { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Logradouro { get; set; }

        [Display(Name = "Ponto de Referência")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string PontoReferencia { get; set; }

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
        [MaxLength(8, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
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

        [Display(Name = "Telefone Principal")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(11, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Telefone1 { get; set; }

        [Display(Name = "Telefone Alternativo")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Telefone2 { get; set; }

        [Display(Name = "Observações")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Observacoes { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^(3[01]|[12][0-9]|0[1-9])[-/](1[0-2]|0[1-9])[-/][0-9]{4}$", ErrorMessage = "A data informada é inválida.")]
        public string DataCadastro { get; set; }
    }
}
