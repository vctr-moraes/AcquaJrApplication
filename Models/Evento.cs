using System;
using System.Collections.Generic;

namespace AcquaJrApplication.Models
{
    public class Evento : Entity
    {
        private string _nome;
        private string _descricao;
        private decimal _valor;
        private string _local;
        private string _pontoReferncia;
        private string _outrasInformacoes;

        /* EF Relations */
        private readonly List<DataEvento> _datas = new List<DataEvento>();
        private readonly List<Convidado> _convidados = new List<Convidado>();

        public string Nome
        {
            get => _nome;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Nome é obrigatório.");
                DomainException.When(value.Trim().Length > 300, "O campo Nome não pode conter mais que 300 caracteres.");
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

        public decimal Valor
        {
            get => _valor;

            set
            {
                DomainException.When(value < 0, "O valor não deve ser negativo.");
                _valor = value;
            }
        }

        public string Local
        {
            get => _local;

            set
            {
                DomainException.When(string.IsNullOrEmpty(value), "O campo Local é obrigatório.");
                DomainException.When(value.Trim().Length > 300, "O campo Local não pode conter mais que 300 caracteres.");
                _local = value.Trim();
            }
        }

        public string PontoReferencia
        {
            get => _pontoReferncia;

            set
            {
                DomainException.When(value.Trim().Length > 300, "O campo Ponto de Referência não pode conter mais que 300 caracteres.");
                _pontoReferncia = value.Trim();
            }
        }

        public string OutrasInformacoes
        {
            get => _outrasInformacoes;

            set
            {
                DomainException.When(value.Trim().Length > 1000, "O campo Outras Informações não pode conter mais que 1000 caracteres.");
                _outrasInformacoes = value.Trim();
            }
        }
    }
}
