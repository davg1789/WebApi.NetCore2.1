using CadastroWebApi.Data.SqlServer.Extension;
using CadastroWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroWebApi.Data.SqlServer.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.IdEndereco);

            builder.Property(e => e.Cep)
               .HasColumnType("varchar(9)")
               .IsRequired();

            builder.Property(e => e.Logradouro)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.Bairro)
            .HasColumnType("varchar(30)")
            .IsRequired();

            builder.Property(e => e.Municipio)
            .HasColumnType("varchar(30)")
            .IsRequired();

            builder.Property(e => e.Numero)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(e => e.Uf)
            .HasColumnType("varchar(2)")
            .IsRequired();

            builder.HasOne(e => e.Pessoa)
                    .WithMany(o => o.Endereco)
                    .HasForeignKey(e => e.IdPessoa);


            builder.ToTable("Endereco");
        }
    }
}
