using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Domain.Entity.Conta
{
    public partial class Conta
    {
        public Conta()
        {

        }
        public Conta(int id, string descricao, decimal valor, DateTime dataCriacao, string tipo)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Valor = valor;
            this.DataCriacao = dataCriacao;
            this.Tipo = tipo;
        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Tipo { get; set; }
    }
}
