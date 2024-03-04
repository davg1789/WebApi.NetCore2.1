using System;
using System.Collections.Generic;
using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Application.Mapper;
using CadastroWebApi.Application.ViewModel;
using CadastroWebApi.Domain.Interfaces.Service;

namespace CadastroWebApi.Application.AppServices
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoService enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
        {
            this.enderecoService = enderecoService;
        }

        public EnderecoViewModel Atualizar(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Map.MapperEnderecoViewModelDomain(enderecoViewModel);
            return Map.MapperDomainEnderecoViewModel(enderecoService.Atualizar(endereco));
        }

        public void Excluir(Guid id)
        {
            enderecoService.Excluir(id);
        }

        public EnderecoViewModel Incluir(EnderecoViewModel enderecoViewModel)
        {
            var telefone = Map.MapperEnderecoViewModelDomain(enderecoViewModel);
            return Map.MapperDomainEnderecoViewModel(enderecoService.Incluir(telefone));
        }

        public EnderecoViewModel Listar(int pagina, int tamanhoPagina)
        {
            return Map.MapperDomainListEnderecoViewModel(enderecoService.Listar(pagina, tamanhoPagina));
        }

        public EnderecoViewModel ObterPorId(Guid id)
        {
            return Map.MapperDomainEnderecoViewModel(enderecoService.ObterPorId(id));
        }
    }
}
