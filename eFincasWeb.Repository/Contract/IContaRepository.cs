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
        Task<Conta> RegistrarConta(Conta conta);
    }
}
