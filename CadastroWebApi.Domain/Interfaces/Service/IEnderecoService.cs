using CadastroWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Endereco Incluir(Endereco pessoa);
        Endereco ObterPorId(Guid id);
        List<Endereco> Listar(int pagina, int tamanhoPagina);
        Endereco Atualizar(Endereco pessoa);
        void Excluir(Guid id);
    }
}
