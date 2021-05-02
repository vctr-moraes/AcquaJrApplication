using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.Models
{
    public enum Cargo
    {
        [Display(Name = "Presidente Executivo")]
        PresidenteExecutivo = 1,

        [Display(Name = "Vice Presidente Executivo")]
        VicePresidenteExecutivo = 2,

        [Display(Name = "Diretor Financeiro")]
        DiretorFinanceiro = 3,

        [Display(Name = "Diretor de Projetos")]
        DiretorProjetos = 4,

        [Display(Name = "Diretor Administrativo")]
        DiretorAdministrativo = 5,

        [Display(Name = "Diretor de Marketing e Relações Públicas")]
        DiretorMarketingRelacoesPublicas = 6,

        [Display(Name = "Diretor de Extensão")]
        DiretorExtensao = 7,

        [Display(Name = "Presidente Administrativo")]
        PresidenteAdministrativo = 8,

        [Display(Name ="Conselheiro Administrativo")]
        ConselheiroAdministrativo = 9,

        [Display(Name = "Honorário")]
        Honorario = 10,

        [Display(Name = "Trainee")]
        Trainne = 11,

        [Display(Name = "Membro Efetivo")]
        MembroEfetivo = 12,

        [Display(Name = "Diretor Administrativo Executivo")]
        DiretorAdministrativoExecutivo = 13
    }
}
