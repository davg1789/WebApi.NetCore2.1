using System;

namespace CadastroWebApi.Domain.Entities
{
    public class Telefone
    {
        public Guid IdTelefone { get; set; }
        public string Tipo { get; set; }
        public long Numero { get; set; }

        public Guid? IdPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public Telefone()
        {
            IdTelefone = Guid.NewGuid();
        }

        public Telefone(Guid idTelefone, string tipo, long numero, Guid? idPessoa)
        {
            IdTelefone = idTelefone;
            Tipo = tipo;
            Numero = numero;
            IdPessoa = idPessoa;
        }
    }
}
