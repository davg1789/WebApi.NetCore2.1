using System;

namespace CadastroWebApi.Domain.Entities
{
    public class Endereco
    {
        public Guid IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public Guid? IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public Endereco()
        {
            IdEndereco = Guid.NewGuid();
        }

        public Endereco(Guid idEndereco, string cep, string logradouro, int numero, string bairro, string municipio, string uf, Guid? idPessoa)
        {
            IdEndereco = idEndereco;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Municipio = municipio;
            Uf = uf;
            IdPessoa = idPessoa;
        }
    }
}
