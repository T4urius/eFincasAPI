using eFincasWeb.Domain.Entity.Conta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Repository.Contract
{
    public interface IContaRepository
    {
        Task<List<Conta>> Listar();
        Task<Conta> GetById(int id);
        Task<Conta> RegistrarConta(Conta conta);
        Task<Conta> AtualizarConta(int id, Conta conta);
        void DeleteConta(int id);
    }
}
