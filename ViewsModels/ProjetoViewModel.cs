using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.ViewsModels
{
    public class ProjetoViewModel
    {
        public ProjetoViewModel() { }

        public ProjetoViewModel(Projeto projeto)
        {
            Id = projeto.Id;
            ClienteId = projeto.ClienteId;
            ServicoId = projeto.ServicoId;
            MembroId = projeto.MembroId;
            Nome = projeto.Nome;
            Descricao = projeto.Descricao;
            CustoMaoDeObra = projeto.CustoMaoDeObra;
            CustoProjeto = projeto.CustoProjeto;
            CustoInsumos = projeto.CustoInsumos;
            Orcamento = projeto.Orcamento;
            Logradouro = projeto.Logradouro;
            PontoReferencia = projeto.PontoReferencia;
            Bairro = projeto.Bairro;
            Cidade = projeto.Cidade;
            Cep = projeto.Cep;
            Estado = projeto.Estado;
            DataContrato = projeto.DataContrato;
            DataPrevista = projeto.DataPrevista;
            DataInicio = projeto.DataInicio;
            DataConclusao = projeto.DataConclusao;
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Membros atuantes no projeto")]
        [Required(ErrorMessage = "É necessário selecionar algum membro atuante no projeto.")]
        public Guid MembroId { get; set; }

        public MembroViewModel Membro { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "É necessário selecionar um {0}.")]
        public Guid ClienteId { get; set; }

        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Serviço")]
        [Required(ErrorMessage = "É necessário selecionar um {0}.")]
        public Guid ServicoId { get; set; }

        public Servico Servico { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Custo da Mão de Obra")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal? CustoMaoDeObra { get; set; }

        [Display(Name = "Custo do Projeto")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal? CustoProjeto { get; set; }

        [Display(Name = "Custo dos Insumos")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal? CustoInsumos { get; set; }

        [Display(Name = "Orçamento")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal? Orcamento { get; set; }

        [Display(Name = "Logradouro")]
        [MaxLength(150, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Logradouro { get; set; }

        [Display(Name = "Ponto de Referência")]
        [MaxLength(200, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string PontoReferencia { get; set; }

        [Display(Name = "Bairro")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cidade { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Estado { get; set; }

        [Display(Name = "Data do Contrato")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime? DataContrato { get; set; }

        [Display(Name = "Data Prevista")]
        [DataType(DataType.Date)]
        public DateTime? DataPrevista { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Data de Conclusão")]
        [DataType(DataType.Date)]
        public DateTime? DataConclusao { get; set; }
    }
}
