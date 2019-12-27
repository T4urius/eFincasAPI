using eFincasWeb.Domain.Entity.Conta;
using eFincasWeb.Repository.Context;
using eFincasWeb.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly FincasDataContext _context;

        public ContaRepository(FincasDataContext context)
        {
            _context = context;
        }

        public async Task<List<Conta>> Listar()
        {
            var data = await _context.Conta.ToListAsync();

            if (data == null)
                return null;

            return data;
        }

        public async Task<Conta> RegistrarConta(Conta conta)
        {
            try
            {
                await _context.Conta.AddAsync(conta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conta;
        }
    }
}
