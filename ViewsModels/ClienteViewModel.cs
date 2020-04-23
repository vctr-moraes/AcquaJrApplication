using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.ViewsModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Tipo Pessoa")]
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
        [MaxLength(500, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Observacoes { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public DateTime DataCadastro { get; set; }
    }
}
