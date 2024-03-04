using System;
using System.Collections.Generic;

namespace CadastroWebApi.Domain.Entities
{
    public class Pessoa
    {
        public Guid IdPessoa { get; set; }
        public string Nome{ get; set; }
        public string CPF { get; set; }
        public string Rg { get; set; }

        public virtual List<Telefone> Telefone { get; set; }
        public virtual List<Endereco> Endereco { get; set; }
        

        public Pessoa()
        {
            IdPessoa = Guid.NewGuid();
        }

        public Pessoa(Guid idPessoa, string nome, string cpf, string rg)
        {
            IdPessoa = idPessoa;
            Nome = nome;
            CPF = cpf;
            Rg = rg;
        }
    }

}
