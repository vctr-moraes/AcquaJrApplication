using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.ViewsModels
{
    public class DataEventoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "É necessário preencher a data do evento.")]
        public DateTime? Data { get; set; }

        [Display(Name = "Hora de Início")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "É necessário preencher a hora de início.")]
        public TimeSpan? HoraInicio { get; set; }

        [Display(Name = "Hora de Encerramento")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "É necessário preencher a hora de encerramento.")]
        public TimeSpan? HoraEncerramento { get; set; }

        public Guid EventoId { get; set; }
    }
}
