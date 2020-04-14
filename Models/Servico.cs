﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Models
{
    public class Servico : Entity
    {
        private string _nome;
        private string _descricao;

        public string Nome
        {
            get => _nome;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Nome é obrigatório.");
                DomainException.When(value.Trim().Length > 100, "O campo Nome não pode conter mais que 100 caracteres.");
                _nome = value.Trim();
            }
        }

        public string Descricao
        {
            get => _descricao;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Descrição é obrigatório.");
                DomainException.When(value.Trim().Length > 1000, "O campo Descrição não pode conter mais que 1000 caracteres.");
                _descricao = value.Trim();
            }
        }
    }
}
