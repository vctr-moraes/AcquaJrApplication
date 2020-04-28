using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Data.Mappings
{
    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Orcamento)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.DataContrato)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(p => p.DataInicio)
                .HasColumnType("DateTime");

            builder.Property(p => p.DataConclusao)
                .HasColumnType("DateTime");

            builder.ToTable("Projetos");
        }
    }
}
