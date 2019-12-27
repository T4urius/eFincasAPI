using eFincasWeb.Domain.Entity;
using eFincasWeb.Domain.Entity.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eFincasWeb.Repository.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Password)
                .HasColumnName("password")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100);

            builder.Property(c => c.Sobrenome)
                .HasColumnName("sobrenome")
                .HasMaxLength(100);

            builder.Property(c => c.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired();

            builder.Property(c => c.Role)
                .HasColumnName("role")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Salt)
                .HasColumnName("salt")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
