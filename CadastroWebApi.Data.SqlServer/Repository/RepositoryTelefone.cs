using CadastroWebApi.Data.SqlServer.Context;
using CadastroWebApi.Domain.Entities;
using CadastroWebApi.Domain.Interfaces.Repository;

namespace CadastroWebApi.Data.SqlServer.Repository
{
    public class RepositoryTelefone : Repository<Telefone>, IRepositoryTelefone
    {
        public RepositoryTelefone(CadastroWebApiContext context)
        : base(context)
        {

        }
    }
}
