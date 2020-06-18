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
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.CustoMaoDeObra)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CustoProjeto)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CustoInsumos)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Orcamento)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Logradouro)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.PontoReferencia)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Bairro)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Estado)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.DataContrato)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.DataPrevista)
                .HasColumnType("date");

            builder.Property(p => p.DataInicio)
                .HasColumnType("date");

            builder.Property(p => p.DataConclusao)
                .HasColumnType("date");

            // 1 : N => Projeto : Membros
            //builder.HasOne(p => p.Membro)
            //    .WithMany(m => m.Projetos)
            //    .OnDelete(DeleteBehavior.Restrict);

            // 1 : 1 => Projeto : Cliente
            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Projetos)
                .OnDelete(DeleteBehavior.Restrict);

            // 1 : 1 => Projeto : Serviço
            builder.HasOne(p => p.Servico)
                .WithMany(s => s.Projetos)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Projetos");
        }
    }
}
