using AcquaJrApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquaJrApplication.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.TipoPessoa)
                .IsRequired();

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.RazaoSocial)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Cnpj)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.InscricaoEstadual)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.RgCtps)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.PontoReferencia)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone1)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Telefone2)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Observacoes)
                .HasColumnType("varchar(500)");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnType("date");

            // 1 : 1 => Cliente : Projeto
            builder.HasOne(c => c.Projeto)
                .WithOne(p => p.Cliente);

            builder.ToTable("Clientes");
        }
    }
}
