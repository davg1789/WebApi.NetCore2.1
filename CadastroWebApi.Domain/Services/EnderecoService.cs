using CadastroWebApi.Domain.Entities;
using CadastroWebApi.Domain.Interfaces.Repository;
using CadastroWebApi.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Domain.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepositoryEndereco repositoryEndereco;

        public EnderecoService(IRepositoryEndereco repositoryEndereco)
        {
            this.repositoryEndereco = repositoryEndereco;
        }

        public Endereco Atualizar(Endereco pessoa)
        {
            return repositoryEndereco.Atualizar(pessoa);
        }

        public void Excluir(Guid id)
        {
            repositoryEndereco.Excluir(id);
        }

        public Endereco Incluir(Endereco pessoa)
        {
            return repositoryEndereco.Incluir(pessoa);
        }

        public List<Endereco> Listar(int pagina, int tamanhoPagina)
        {
            return repositoryEndereco.Listar(pagina, tamanhoPagina);
        }

        public Endereco ObterPorId(Guid id)
        {
            return repositoryEndereco.ObterPorId(id);
        }
    }
}
