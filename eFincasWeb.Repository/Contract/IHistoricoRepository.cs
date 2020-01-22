using eFincasWeb.Domain.Entity.Historico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Repository.Contract
{
    public interface IHistoricoRepository
    {
        Task<IList<Historico>> ListarHistorico();
        Task<Historico> RegistrarHistorico(Historico historico);
    }
}
