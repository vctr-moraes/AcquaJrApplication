using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.Models
{
    public enum Cargo
    {
        [Display(Name = "Presidente")]
        Presidente = 1,

        [Display(Name = "Vice Presidente")]
        VicePresidente = 2,

        [Display(Name = "Diretor Financeiro")]
        DiretorFinanceiro = 3,

        [Display(Name = "Diretor de Projetos")]
        DiretorProjetos = 4,

        [Display(Name = "Diretor Administrativo")]
        DiretorAdministrativo = 5,

        [Display(Name = "Diretor de Marketing e Relações Públicas")]
        DiretorMarketingRelacoesPublicas = 6,

        [Display(Name = "Diretor de Extensão")]
        DiretorExtensao = 7
    }
}
