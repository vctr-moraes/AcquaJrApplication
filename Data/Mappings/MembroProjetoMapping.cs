using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcquaJrApplication.Data.Mappings
{
    public class MembroProjetoMapping : IEntityTypeConfiguration<MembroProjeto>
    {
        public void Configure(EntityTypeBuilder<MembroProjeto> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.MembroId)
                .IsRequired();

            builder.Property(m => m.ProjetoId)
                .IsRequired();

            builder.ToTable("MembrosProjetos");
        }
    }
}
