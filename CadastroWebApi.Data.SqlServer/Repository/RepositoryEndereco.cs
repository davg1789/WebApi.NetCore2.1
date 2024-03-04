using CadastroWebApi.Data.SqlServer.Context;
using CadastroWebApi.Domain.Entities;
using CadastroWebApi.Domain.Interfaces.Repository;

namespace CadastroWebApi.Data.SqlServer.Repository
{
    public class RepositoryEndereco : Repository<Endereco>, IRepositoryEndereco
    {
        public RepositoryEndereco(CadastroWebApiContext context)
        : base(context)
        {

        }    
    }
}
