using System;
using System.ComponentModel.DataAnnotations;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.ViewsModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel() { }

        public ServicoViewModel(Servico servico)
        {
            Id = servico.Id;
            Nome = servico.Nome;
            Descricao = servico.Descricao;
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(700, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Descricao { get; set; }
    }
}
