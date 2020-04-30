using System;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.ViewsModels
{
    public class ProjetoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "É necessário selecionar um {0}.")]
        public Guid _clienteId { get; set; }

        [Display(Name = "Serviço")]
        [Required(ErrorMessage = "É necessário selecionar um {0}.")]
        public Guid _servicoId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string _nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string _descricao { get; set; }

        [Display(Name = "Orçamento")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal _orcamento { get; set; }

        [Display(Name = "Data do Contrato")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime _dataContrato { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime? _dataInicio { get; set; }

        [Display(Name = "Data de Conclusão")]
        [DataType(DataType.Date)]
        public DateTime? _dataConclusao { get; set; }
    }
}
