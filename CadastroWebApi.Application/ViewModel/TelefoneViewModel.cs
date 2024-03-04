using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CadastroWebApi.Application.ViewModel
{
    [DataContract(Name = "telefones")]
    public class TelefoneViewModel
    {
        public TelefoneViewModel()
        {
            IdTelefone = Guid.NewGuid();
        }

        public TelefoneViewModel(Guid idTelefone, string tipo, long numero, Guid? idPessoa)
        {
            IdTelefone = idTelefone;
            Tipo = tipo;            
            Numero = numero;
            IdPessoa = idPessoa;
        }

        [DataMember(Name = "idTelefone")]
        public Guid IdTelefone { get; set; }

        [Required(ErrorMessage = "Tipo de telefone é obrigatório")]
        [DataMember(Name = "tipo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Numero do telefone é obrigatório")]
        [DataMember(Name = "numero")]
        public long Numero { get; set; }
        
        [DataMember(Name = "idPessoa")]
        public Guid? IdPessoa { get; set; }

        [DataMember(Name = "messages")]
        public List<string> Messages { get; set; }
    }
}
