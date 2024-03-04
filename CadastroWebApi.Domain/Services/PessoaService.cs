using CadastroWebApi.Domain.Entities;
using CadastroWebApi.Domain.Interfaces.Repository;
using CadastroWebApi.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroWebApi.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepositoryPessoa repositoryPessoa;

        public PessoaService(IRepositoryPessoa repositoryPessoa)
        {
            this.repositoryPessoa = repositoryPessoa;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            return repositoryPessoa.Atualizar(pessoa);
        }

        public void Excluir(Guid id)
        {
            repositoryPessoa.Excluir(id);
        }

        public Pessoa Incluir(Pessoa pessoa)
        {
            return repositoryPessoa.Incluir(pessoa);
        }

        public List<Pessoa> Listar(int pagina, int tamanhoPagina)
        {
            return repositoryPessoa.Listar(pagina, tamanhoPagina);
        }

        public Pessoa ObterPorId(Guid id)
        {
            return repositoryPessoa.ObterPorId(id);
        }
    }
}
