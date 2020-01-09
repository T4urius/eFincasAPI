using eFincasWeb.Domain.Entity.Conta;
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
    public class ContaRepository : IContaRepository
    {
        private readonly FincasDataContext _context;

        public ContaRepository(FincasDataContext context)
        {
            _context = context;
        }

        public async Task<Conta> AtualizarConta(int id, Conta conta)
        {
            conta.Id = id;

            try
            {
                _context.Conta.Update(conta);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conta;
        }

        public void DeleteConta(int id)
        {
            var data = _context.Conta.Where(e => e.Id.Equals(id)).FirstOrDefault();

            if (data != null)
            {
                try
                {
                    _context.Conta.Remove(data);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<List<Conta>> Listar()
        {
            var data = await _context.Conta.AsQueryable().OrderByDescending(e => e.DataCriacao).ToListAsync();

            if (data == null)
                return null;

            return data;
        }

        public async Task<Conta> RegistrarConta(Conta conta)
        {
            var data = await _context.Conta.Where(e => e.Id.Equals(conta.Id)).ToListAsync();

            if (!data.Any())
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
            }

            return conta;
        }
    }
}
