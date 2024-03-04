using CadastroWebApi.Domain.Entities;
using CadastroWebApi.Domain.Interfaces.Repository;
using CadastroWebApi.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroWebApi.Domain.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly IRepositoryTelefone repositoryTelefone;

        public TelefoneService(IRepositoryTelefone repositoryTelefone)
        {
            this.repositoryTelefone = repositoryTelefone;
        }

        public Telefone Atualizar(Telefone telefone)
        {
            return repositoryTelefone.Atualizar(telefone);
        }

        public void Excluir(Guid id)
        {
            repositoryTelefone.Excluir(id);
        }

        public Telefone Incluir(Telefone telefone)
        {
            return repositoryTelefone.Incluir(telefone);
        }

        public List<Telefone> Listar(int pagina, int tamanhoPagina)
        {
            return repositoryTelefone.Listar(pagina, tamanhoPagina);
        }

        public Telefone ObterPorId(Guid id)
        {
            return repositoryTelefone.ObterPorId(id);
        }
    }
}
