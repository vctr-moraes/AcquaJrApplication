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
        EngenhariaAquicultura = 1,

        [Display(Name = "Bacharelado em Ciências Biológicas")]
        BachareladoBiologia = 2,

        [Display(Name = "Licenciatura em Ciências Biológicas")]
        LicenciaturaBiologia = 3,

        [Display(Name = "Cafeicultura")]
        Cafeicultura = 4,

        [Display(Name = "Análise e Desenvolvimento de Sistemas")]
        AnaliseDesenvolvimentoSistemas = 5
    }
}
