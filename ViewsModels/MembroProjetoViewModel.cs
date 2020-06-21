using System;
using System.ComponentModel.DataAnnotations;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.ViewsModels
{
    public class MembroProjetoViewModel
    {
        public MembroProjetoViewModel() { }

        public MembroProjetoViewModel(MembroProjeto membroProjeto)
        {
            Id = membroProjeto.Id;
            Membro = membroProjeto.Membro;
            MembroId = membroProjeto.MembroId;
            Projeto = membroProjeto.Projeto;
            ProjetoId = membroProjeto.ProjetoId;
        }

        [Key]
        public Guid Id { get; set; }
        
        [Display(Name = "Membro")]
        public Membro Membro { get; set; }

        [Display(Name = "Membro")]
        public Guid MembroId { get; set; }

        [Display(Name = "Projeto")]
        public Projeto Projeto { get; set; }

        [Display(Name = "Projeto")]
        public Guid ProjetoId { get; set; }
    }
}
