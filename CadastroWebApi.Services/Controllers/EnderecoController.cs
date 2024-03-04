using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Services.Controllers
{
    public class EnderecoController : BaseController
    {
        private readonly IEnderecoAppService enderecoAppService;

        public EnderecoController(IEnderecoAppService enderecoAppService)
        {
            this.enderecoAppService = enderecoAppService;
        }

        [HttpPost]
        [Route("endereco/incluir")]
        [AllowAnonymous]
        public EnderecoViewModel Post([FromBody] EnderecoViewModel enderecoViewModel)
        {
            if (ValidarRequisicao())
            {
                return enderecoAppService.Incluir(enderecoViewModel);
            }
            else
            {
                var responseError = new EnderecoViewModel();
                responseError.Messages = ObterErroModelInvalida();
                return responseError;
            }
        }

        [HttpPut]
        [Route("endereco/alterar")]
        [AllowAnonymous]
        public EnderecoViewModel Put([FromBody] EnderecoViewModel enderecoViewModel)
        {
            if (ValidarRequisicao())
            {
                return enderecoAppService.Atualizar(enderecoViewModel);
            }
            else
            {
                var responseError = new EnderecoViewModel();
                responseError.Messages = ObterErroModelInvalida();
                return responseError;
            }
        }

        [HttpDelete]
        [Route("endereco/excluir")]
        [AllowAnonymous]
        public EnderecoViewModel Delete(Guid id)
        {
            enderecoAppService.Excluir(id);
            var endereco = new EnderecoViewModel();
            endereco.Messages = new List<string>();
            endereco.Messages.Add("Registro excluído com sucesso!");
            return endereco;
        }

        [HttpGet]
        [Route("endereco/listar")]
        [AllowAnonymous]
        public EnderecoViewModel Get([FromQuery] int pagina, int tamanhoPagina)
        {
            return enderecoAppService.Listar(pagina, tamanhoPagina);
        }

        [HttpGet]
        [Route("endereco/obterPorId")]
        [AllowAnonymous]
        public EnderecoViewModel Get([FromQuery] Guid id)
        {
            return enderecoAppService.ObterPorId(id);
        }
    }
}
