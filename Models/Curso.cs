using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.Models
{
    public enum Curso
    {
        [Display(Name = "Engenharia de Aquicultura")]
        Aquicultura = 1,

        [Display(Name = "Bacharelado em Ciências Biológicas")]
        BiologiaBacharelado = 2,

        [Display(Name = "Licenciatura em Ciências Biológicas")]
        BiologiaLicenciatura = 3,

        [Display(Name = "Cafeicultura")]
        Cafeicultura = 4,

        [Display(Name = "Análise e Desenvolvimento de Sistemas")]
        AnaliseDeSistemas = 5
    }
}
