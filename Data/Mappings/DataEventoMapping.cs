using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Data.Mappings
{
    public class DataEventoMapping : IEntityTypeConfiguration<DataEvento>
    {
        public void Configure(EntityTypeBuilder<DataEvento> builder)
        {
            builder.Property(d => d.Id);

            builder.Property(d => d.Data)
                .HasColumnType("date");

            builder.ToTable("DataEventos");
        }
    }
}
