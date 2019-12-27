using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Model.Request.Conta
{
    public class AtualizarContaRequest
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
