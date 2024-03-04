using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Services.Controllers
{
    public class PessoaController : BaseController
    {
        private readonly IPessoaAppService pessoaAppService;

        public PessoaController(IPessoaAppService pessoaAppService)
        {
            this.pessoaAppService = pessoaAppService;
        }

        [HttpPost]
        [Route("pessoa/incluir")]
        [AllowAnonymous]
        public PessoaViewModel Post([FromBody] PessoaViewModel pessoaViewModel)
        {
            if (ValidarRequisicao())
            {
                return pessoaAppService.Incluir(pessoaViewModel);
            }
            else
            {
                var responseError = new PessoaViewModel();
                responseError.Messages = ObterErroModelInvalida();
                return responseError;
            }
        }

        [HttpPut]
        [Route("pessoa/alterar")]
        [AllowAnonymous]
        public PessoaViewModel Put([FromBody] PessoaViewModel pessoaViewModel)
        {
            if (ValidarRequisicao())
            {
                return pessoaAppService.Atualizar(pessoaViewModel);
            }
            else
            {
                var responseError = new PessoaViewModel();
                responseError.Messages = ObterErroModelInvalida();
                return responseError;
            }
        }

        [HttpDelete]
        [Route("pessoa/excluir")]
        [AllowAnonymous]
        public PessoaViewModel Delete(Guid id)
        {
            pessoaAppService.Excluir(id);
            var pessoa = new PessoaViewModel();
            pessoa.Messages = new List<string>();
            pessoa.Messages.Add("Registro excluído com sucesso!");
            return pessoa;
        }

        [HttpGet]
        [Route("pessoa/listar")]
        [AllowAnonymous]
        public List<PessoaViewModel> Get([FromQuery] int pagina, int tamanhoPagina)
        {
            return pessoaAppService.Listar(pagina, tamanhoPagina);
        }

        [HttpGet]
        [Route("pessoa/obterPorId")]
        [AllowAnonymous]
        public PessoaViewModel Get([FromQuery] Guid id)
        {
            return pessoaAppService.ObterPorId(id);
        }
    }
}
