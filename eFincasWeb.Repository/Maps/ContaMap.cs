using eFincasWeb.Domain.Entity.Conta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Repository.Maps
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(c => c.Valor)
                .HasColumnName("valor")
                .IsRequired();

            builder.Property(c => c.Tipo)
                .HasColumnName("tipo")
                .IsRequired();

            builder.Property(c => c.DataCriacao)
                .HasColumnName("data_criacao")
                .IsRequired();
        }
    }
}
