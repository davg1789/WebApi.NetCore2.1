using CadastroWebApi.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Application.Interfaces
{
    public interface IEnderecoAppService
    {
        EnderecoViewModel Incluir(EnderecoViewModel endereco);
        EnderecoViewModel ObterPorId(Guid id);
        EnderecoViewModel Listar(int pagina, int tamanhoPagina);
        EnderecoViewModel Atualizar(EnderecoViewModel endereco);
        void Excluir(Guid id);
    }
}
