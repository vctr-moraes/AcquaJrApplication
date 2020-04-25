using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquaJrApplication.Data.Mappings
{
    public class MembroMapping : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(m => m.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(m => m.DataNascimento)
                .IsRequired();

            builder.Property(m => m.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(m => m.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(m => m.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(m => m.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(m => m.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(m => m.Telefone)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(m => m.Curso)
                .IsRequired();

            builder.Property(m => m.MatriculaAcademica)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(m => m.Cargo)
                .IsRequired();

            builder.Property(m => m.DataEntrada)
                .IsRequired();

            builder.ToTable("Membros");
        }
    }
}
