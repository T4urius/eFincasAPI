using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Domain.Entity.Historico
{
    public partial class Historico
    {
        public int Id { get; set; } = 0;
        public DateTime DataExclusao { get; set; } = DateTime.Now;
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
