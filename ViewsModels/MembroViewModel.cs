﻿using AcquaJrApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcquaJrApplication.ViewsModels
{
    public class MembroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(11, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Estado { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(11, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string Telefone { get; set; }

        [Display(Name = "Possui seguro de vida?")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool TemSeguro { get; set; }

        [Display(Name = "Possui CNH?")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool TemCnh { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Curso Curso { get; set; }

        [Display(Name = "Matrícula Acadêmica")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo {0} não pode conter mais que {1} caracteres.")]
        public string MatriculaAcademica { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Cargo Cargo { get; set; }

        [Display(Name = "Data de Entrada")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data de Saída")]
        [DataType(DataType.Date)]
        public DateTime? DataSaida { get; set; }
    }
}
