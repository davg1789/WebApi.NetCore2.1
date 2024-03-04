using CadastroWebApi.Data.SqlServer.Context;
using CadastroWebApi.Domain.Entities;
using CadastroWebApi.Domain.Interfaces.Repository;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroWebApi.Data.SqlServer.Repository
{
    public class RepositoryPessoa : Repository<Pessoa>, IRepositoryPessoa
    {
        public RepositoryPessoa(CadastroWebApiContext context)
        : base(context)
        {

        }

        public override Pessoa ObterPorId(Guid id)
        {
            var sql = @"SELECT p.idPessoa, nome, cpf, rg, idEndereco, cep, logradouro, e.numero, " +
                       " bairro, municipio, uf, " +
                      " IdTelefone, tipo, t.numero " +
                      " FROM Pessoa P " +
                      " LEFT JOIN Endereco e on e.idPessoa = p.idPessoa " +
                      " LEFT JOIN Telefone t on t.idPessoa = p.idPessoa " +
                      " WHERE p.idPessoa = @idPessoa ";

            var telefones = new List<Telefone>();

            var pessoa = Db.Database.GetDbConnection().Query<Pessoa, Endereco, Telefone, Pessoa>(sql,
                (p, en, te) =>
                {
                    if (en != null)
                    {
                        p.Endereco = new List<Endereco>();
                        p.Endereco.Add(en);
                    }

                    if (te != null)
                    {                        
                        telefones.Add(te);                        
                    }
                    return p;
                },
                new { idPessoa = id }
                , splitOn: "idPessoa, idEndereco, idTelefone ").FirstOrDefault();

            if(telefones.Count > 0)
            {
                pessoa.Telefone = telefones;
            }
            
           
            return pessoa;
        }

        public override List<Pessoa> Listar(int pagina, int tamanhoPagina)
        {
            return DbSet.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina)
                .Include(p => p.Endereco)
                .Include(p => p.Telefone).ToList();
        }
    }
}
