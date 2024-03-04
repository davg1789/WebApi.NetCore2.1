using CadastroWebApi.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroWebApi.Application.Interfaces
{
    public interface IPessoaAppService
    {
        PessoaViewModel Incluir(PessoaViewModel pessoa);
        PessoaViewModel ObterPorId(Guid id);
        List<PessoaViewModel> Listar(int pagina, int tamanhoPagina);
        PessoaViewModel Atualizar(PessoaViewModel pessoa);
        void Excluir(Guid id);
    }
}
