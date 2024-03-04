using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Application.Mapper;
using CadastroWebApi.Application.ViewModel;
using CadastroWebApi.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroWebApi.Application.AppServices
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaService pessoaService;
        private readonly IEnderecoAppService enderecoAppService;
        private readonly ITelefoneAppService telefoneAppService;

        public PessoaAppService(IPessoaService pessoaService, IEnderecoAppService enderecoAppService, ITelefoneAppService telefoneAppService)
        {
            this.pessoaService = pessoaService;
            this.enderecoAppService = enderecoAppService;
            this.telefoneAppService = telefoneAppService;
        }

        public PessoaViewModel Atualizar(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Map.MapperPessoaViewModelDomain(pessoaViewModel);
            return Map.MapperDomainPessoaViewModel(pessoaService.Atualizar(pessoa));
        }

        public void Excluir(Guid id)
        {
            pessoaService.Excluir(id);
        }

        public PessoaViewModel Incluir(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Map.MapperPessoaViewModelDomain(pessoaViewModel);            
            var pessoaViewModelRetorno = Map.MapperDomainPessoaViewModel(pessoaService.Incluir(pessoa));

            if (pessoaViewModel.Endereco != null)
            {
                pessoaViewModel.Endereco.IdPessoa = pessoaViewModelRetorno.IdPessoa;
                enderecoAppService.Incluir(pessoaViewModel.Endereco);
            }

            if (pessoaViewModel.Telefones != null)
            {
                foreach(var telefone in pessoaViewModel.Telefones)
                {
                   telefone.IdPessoa = pessoaViewModelRetorno.IdPessoa;
                    telefoneAppService.Incluir(telefone);
                }                
            }

            return pessoaViewModelRetorno;

        }

        public List<PessoaViewModel> Listar(int pagina, int tamanhoPagina)
        {
            return Map.MapperDomainListPessoaViewModelList(pessoaService.Listar(pagina, tamanhoPagina));
        }

        public PessoaViewModel ObterPorId(Guid id)
        {
            return Map.MapperDomainPessoaViewModel(pessoaService.ObterPorId(id));
        }
    }
}
