using eFincasWeb.Domain.Entity;
using eFincasWeb.Domain.Entity.Usuario;
using eFincasWeb.Model.Response;
using eFincasWeb.Repository.Context;
using eFincasWeb.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Repository
{
    public class LoginRepository : ILoginRepository
    {
        #region Variáveis
        public readonly FincasDataContext _context;
        #endregion

        #region Construtor
        public LoginRepository(FincasDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        //Método de login
        public async Task<Usuario> Login(string email, string pass)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == email);
            if (usuario == null)
                return null;

            if (!VerifyPasswordHash(pass, usuario.Password, usuario.Salt))
                return null;

            return usuario;
        }

        //Método de registro
        public async Task<Usuario> Registrar(Usuario usuario, string pass)
        {
            CreatePasswordHash(pass, out byte[] passwordHash, out byte[] salt);
            usuario.Password = passwordHash;
            usuario.Salt = salt;
            usuario.DataCadastro = DateTime.Now;

            try
            {
                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return usuario;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
        #endregion
    }
}
