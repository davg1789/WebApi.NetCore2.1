using CadastroWebApi.Data.SqlServer.Context;
using CadastroWebApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroWebApi.Data.SqlServer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected CadastroWebApiContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(CadastroWebApiContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Atualizar(TEntity obj)
        {
            var objResult = DbSet.Update(obj);
            var result = Db.SaveChanges();
            return objResult.Entity;
        }

        public void Excluir(Guid id)
        {
            try
            {
                DbSet.Remove(DbSet.Find(id));
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                //log   
            }         
        }

        public TEntity Incluir(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            var result = Db.SaveChanges();
            return objreturn.Entity;
        }

        public virtual List<TEntity> Listar(int pagina, int tamanhoPagina)
        {
            return DbSet.Skip((pagina -1) * tamanhoPagina).Take(tamanhoPagina).ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }
    }
}
