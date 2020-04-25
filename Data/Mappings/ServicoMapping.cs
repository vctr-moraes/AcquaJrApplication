using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquaJrApplication.Data.Mappings
{
    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasColumnType("varchar(700)");

            builder.ToTable("Servicos");
        }
    }
}
