using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Domain.Entity.Usuario
{
    public partial class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int id, string email, byte[] password, string nome, string sobrenome, DateTime dataCadastro, string role, byte[] salt)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DataCadastro = dataCadastro;
            this.Role = role;
            this.Salt = salt;
        }

        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] Password { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Role { get; set; } = "User";
        public virtual byte[] Salt { get; set; }
        public virtual DateTime DataCadastro { get; set; }
    }
}
