using System;
using System.Collections.Generic;

namespace CadastroWebApi.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Incluir(TEntity obj);
        TEntity ObterPorId(Guid id);
        List<TEntity>  Listar(int pagina, int tamanhoPagina);
        TEntity Atualizar(TEntity obj);
        void Excluir(Guid id);
    }
}
