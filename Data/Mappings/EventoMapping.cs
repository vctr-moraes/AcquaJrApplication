using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Data.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(e => e.Descricao)
                .HasColumnType("varchar(1000)");

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Local)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.PontoReferencia)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.OutrasInformacoes)
                .HasColumnType("varchar(1000)");

            // 1 : N => Evento : Datas
            builder.HasMany(e => e.Datas)
                .WithOne(d => d.Evento)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 : N => Evento : Convidados
            builder.HasMany(e => e.Convidados)
                .WithOne(c => c.Evento)
                .HasForeignKey(c => c.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Eventos");
        }
    }
}
