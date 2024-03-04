using CadastroWebApi.Data.SqlServer.Extension;
using CadastroWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroWebApi.Data.SqlServer.Mappings
{
    public class TelefoneMapping : EntityTypeConfiguration<Telefone>
    {
        public override void Map(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(c => c.IdTelefone);

            builder.Property(e => e.Numero)
               .HasColumnType("bigint")
               .IsRequired();

            builder.Property(e => e.Tipo)
               .HasColumnType("varchar(10)")
               .IsRequired();            

            builder.HasOne(e => e.Pessoa)
                    .WithMany(o => o.Telefone)
                    .HasForeignKey(e => e.IdPessoa);           


            builder.ToTable("Telefone");
        }
    }
}
