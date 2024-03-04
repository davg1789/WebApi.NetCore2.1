using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CadastroWebApi.Application.ViewModel
{
    [DataContract(Name = "pessoa")]
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            IdPessoa = Guid.NewGuid();
        }

        public PessoaViewModel(Guid idPessoa, string nome, string cpf, string rg)
        {
            IdPessoa = idPessoa;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
        }

        [DataMember(Name = "idPessoa")]
        public Guid IdPessoa { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [DataMember(Name = "cpf")]
        public string Cpf { get; set; }

        [DataMember(Name = "rg")]
        public string Rg { get; set; }

        [DataMember(Name = "endereco")]
        public EnderecoViewModel Endereco { get; set; }

        [DataMember(Name = "telefones")]
        public List<TelefoneViewModel> Telefones { get; set; }

        [DataMember(Name = "messages")]
        public List<string> Messages { get; set; }
    }
}
