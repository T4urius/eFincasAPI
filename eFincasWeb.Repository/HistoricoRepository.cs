using eFincasWeb.Domain.Entity.Historico;
using eFincasWeb.Repository.Context;
using eFincasWeb.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Repository
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly FincasDataContext _context;

        public HistoricoRepository(FincasDataContext context)
        {
            _context = context;
        }

        public async Task<Historico> RegistrarHistorico(Historico historico)
        {
            var data = await _context.Historico.Where(e => e.Id.Equals(historico.Id)).ToListAsync();

            if (!data.Any())
            {
                try
                {
                    historico.Id = 0;
                    await _context.Historico.AddAsync(historico);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return historico;
        }
    }
}
