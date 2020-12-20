using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Data.Mappings
{
    public class ConvidadoMapping : IEntityTypeConfiguration<Convidado>
    {
        public void Configure(EntityTypeBuilder<Convidado> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Estado)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Instituicao)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Participacao)
                .HasColumnType("varchar(200)");

            builder.ToTable("Convidados");
        }
    }
}
