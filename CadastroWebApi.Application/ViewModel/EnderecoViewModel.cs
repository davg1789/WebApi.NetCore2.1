using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.Serialization;

namespace CadastroWebApi.Application.ViewModel
{
    [DataContract(Name = "endereco")]
    public class EnderecoViewModel 
    { 
            public EnderecoViewModel()
            {
                IdEndereco = Guid.NewGuid();               
            }

            public EnderecoViewModel(Guid idEndereco, string cep, string logradouro, int numero, string bairro,
                string municipio,string uf, Guid? idPessoa)
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

            [DataMember(Name = "idEndereco")]
            public Guid IdEndereco { get; set; }

            [Required(ErrorMessage = "Cep é obrigatório")]
            [DataMember(Name = "cep")]
            public string Cep { get; set; }

            [Required(ErrorMessage = "Logradouro é obrigatório")]
            [DataMember(Name = "logradouro")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "Número é obrigatório")]
            [DataMember(Name = "numero")]
            public int Numero { get; set; }

            [Required(ErrorMessage = "Bairro é obrigatório")]
            [DataMember(Name = "bairro")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "Município é obrigatório")]
            [DataMember(Name = "municipio")]
            public string Municipio { get; set; }

            [Required(ErrorMessage = "UF é obrigatória")]
            [DataMember(Name = "uf")]
            public string Uf { get; set; }
            
            [DataMember(Name = "idPessoa")]
            public Guid? IdPessoa { get; set; }

            [DataMember(Name = "messages")]
            public List<string> Messages { get; set; }


    }
}
