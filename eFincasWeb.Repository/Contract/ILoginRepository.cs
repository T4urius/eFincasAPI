using eFincasWeb.Domain.Entity;
using eFincasWeb.Domain.Entity.Usuario;
using eFincasWeb.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Repository.Contract
{
    public interface ILoginRepository
    {
        Task<Usuario> Login(string email, string pass);
        Task<Usuario> Registrar(Usuario usuario, string pass);
    }
}
