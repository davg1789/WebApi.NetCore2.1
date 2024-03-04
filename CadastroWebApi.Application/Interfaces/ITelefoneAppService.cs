using CadastroWebApi.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Application.Interfaces
{
    public interface ITelefoneAppService
    {
        TelefoneViewModel Incluir(TelefoneViewModel telefone);
        TelefoneViewModel ObterPorId(Guid id);
        List<TelefoneViewModel> Listar(int pagina, int tamanhoPagina);
        TelefoneViewModel Atualizar(TelefoneViewModel telefone);
        void Excluir(Guid id);
    }
}
