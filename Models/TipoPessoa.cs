using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.Models
{
    public enum TipoPessoa
    {
        [Display(Name = "Pessoa Física")]
        PessoaFisica = 1,

        [Display(Name = "Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}
