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
        public DateTime Data { get; set; }

        [Display(Name = "Hora de Início")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "Hora de Encerramento")]
        [DataType(DataType.Time)]
        public TimeSpan HoraEncerramento { get; set; }

        public Guid EventoId { get; set; }
    }
}
