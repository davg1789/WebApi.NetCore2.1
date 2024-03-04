using CadastroWebApi.Data.SqlServer.Extension;
using CadastroWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroWebApi.Data.SqlServer.Mappings
{
    public class PessoaMapping : EntityTypeConfiguration<Pessoa>
    {
        public override void Map(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(c => c.IdPessoa);

            builder.Property(e => e.CPF)
               .HasColumnType("varchar(15)")
               .IsRequired();

            builder.Property(e => e.Rg)
               .HasColumnType("varchar(20)");
               

            builder.Property(e => e.Nome)
               .HasColumnType("varchar(50)")
               .IsRequired();     


            builder.ToTable("Pessoa");
        }
    }
}
