using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.ViewsModels
{
    public class ConvidadoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Cidade")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Estado { get; set; }

        [Display(Name = "Instituição")]
        [MaxLength(200, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Instituicao { get; set; }

        [Display(Name = "Participação")]
        [MaxLength(200, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Participacao { get; set; }

        public Guid EventoId { get; set; }
    }
}
