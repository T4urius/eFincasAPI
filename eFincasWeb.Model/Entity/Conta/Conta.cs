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
        public Conta(int id, string descricao, decimal valor, DateTime dataCriacao)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Valor = valor;
            this.DataCriacao = dataCriacao;
        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
