using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Model.Request.Conta
{
    public class AtualizarContaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
