using CadastroWebApi.Data.SqlServer.Extension;
using CadastroWebApi.Data.SqlServer.Mappings;
using CadastroWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CadastroWebApi.Data.SqlServer.Context
{
    public class CadastroWebApiContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }       
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.AddConfiguration(new PessoaMapping());
            modelBuilder.AddConfiguration(new TelefoneMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());
            

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
