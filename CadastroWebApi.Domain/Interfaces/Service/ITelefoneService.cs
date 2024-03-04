using CadastroWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Domain.Interfaces.Service
{
    public interface ITelefoneService
    {
        Telefone Incluir(Telefone pessoa);
        Telefone ObterPorId(Guid id);
        List<Telefone> Listar(int pagina, int tamanhoPagina);
        Telefone Atualizar(Telefone pessoa);
        void Excluir(Guid id);
    }
}
