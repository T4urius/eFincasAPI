using eFincasWeb.Domain.Entity;
using eFincasWeb.Domain.Entity.Conta;
using eFincasWeb.Domain.Entity.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Repository.Context
{
    public class FincasDataContext : DbContext
    {
        public FincasDataContext(DbContextOptions<FincasDataContext> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.UsuarioMap());
            modelBuilder.ApplyConfiguration(new Maps.ContaMap());
        }
    }
}
