using CadastroWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Domain.Interfaces.Service
{
    public interface IPessoaService
    {
        Pessoa Incluir(Pessoa pessoa);
        Pessoa ObterPorId(Guid id);
        List<Pessoa> Listar(int pagina, int tamanhoPagina);
        Pessoa Atualizar(Pessoa pessoa);
        void Excluir(Guid id);
    }
}
