using AcquaJrApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.ViewsModels
{
    public class EventoViewModel
    {
        public EventoViewModel() { }

        public EventoViewModel(Evento evento)
        {
            Id = evento.Id;
            Nome = evento.Nome;
            Descricao = evento.Descricao;
            Valor = evento.Valor;
            Local = evento.Local;
            PontoReferencia = evento.PontoReferencia;
            OutrasInformacoes = evento.OutrasInformacoes;
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get; set; }

        [Display(Name = "Local")]
        [MaxLength(300, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Local { get; set; }

        [Display(Name = "Ponto de Referência")]
        [MaxLength(300, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string PontoReferencia { get; set; }

        [Display(Name = "Outras Informações")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string OutrasInformacoes { get; set; }

        public List<DataEventoViewModel> Datas { get; set; }

        public List<ConvidadoViewModel> Convidados { get; set; }
    }
}
