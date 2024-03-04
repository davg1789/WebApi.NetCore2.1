using System;
using System.Collections.Generic;
using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Application.Mapper;
using CadastroWebApi.Application.ViewModel;
using CadastroWebApi.Domain.Interfaces.Service;

namespace CadastroWebApi.Application.AppServices
{
    public class TelefoneAppService : ITelefoneAppService
    {
        private readonly ITelefoneService telefoneService;

        public TelefoneAppService(ITelefoneService telefoneService)
        {
            this.telefoneService = telefoneService;
        }

        public TelefoneViewModel Atualizar(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Map.MapperTelefoneViewModelDomain(telefoneViewModel);
            return Map.MapperDomainTelefoneViewModel(telefoneService.Atualizar(telefone));
        }

        public void Excluir(Guid id)
        {
            telefoneService.Excluir(id);
        }

        public TelefoneViewModel Incluir(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Map.MapperTelefoneViewModelDomain(telefoneViewModel);
            return Map.MapperDomainTelefoneViewModel(telefoneService.Incluir(telefone));
        }

        public List<TelefoneViewModel> Listar(int pagina, int tamanhoPagina)
        {
            return Map.MapperDomainListTelefoneViewModelList(telefoneService.Listar(pagina, tamanhoPagina));
        }

        public TelefoneViewModel ObterPorId(Guid id)
        {
            return Map.MapperDomainTelefoneViewModel(telefoneService.ObterPorId(id));
        }
    }
}
