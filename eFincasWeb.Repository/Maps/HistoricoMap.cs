using eFincasWeb.Domain.Entity.Historico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Repository.Maps
{
    public class HistoricoMap : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.ToTable("Historico");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(c => c.DataExclusao)
                .HasColumnName("data_exclusao")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao");

            builder.Property(c => c.Valor)
            .HasColumnName("valor")
            .IsRequired();

            builder.Property(c => c.Tipo)
            .HasColumnName("tipo")
            .IsRequired();

            builder.Property(c => c.DataInclusao)
                .HasColumnName("data_inclusao")
                .IsRequired();

        }
    }
}
