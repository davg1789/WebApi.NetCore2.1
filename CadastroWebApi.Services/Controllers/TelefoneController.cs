using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Services.Controllers
{
    public class TelefoneController : BaseController
    {
        private readonly ITelefoneAppService telefoneAppService;

        public TelefoneController(ITelefoneAppService telefoneAppService)
        {
            this.telefoneAppService = telefoneAppService;
        }

        [HttpPost]
        [Route("telefone/incluir")]
        [AllowAnonymous]
        public TelefoneViewModel Post([FromBody] TelefoneViewModel telefoneViewModel)
        {
            if (ValidarRequisicao())
            {
                return telefoneAppService.Incluir(telefoneViewModel);
            }
            else
            {
                var responseError = new TelefoneViewModel();
                responseError.Messages = ObterErroModelInvalida();
                return responseError;
            }
        }

        [HttpPut]
        [Route("telefone/alterar")]
        [AllowAnonymous]
        public TelefoneViewModel Put([FromBody] TelefoneViewModel telefoneViewModel)
        {
            if (ValidarRequisicao())
            {
                return telefoneAppService.Atualizar(telefoneViewModel);
            }
            else
            {
                var responseError = new TelefoneViewModel();
                responseError.Messages = ObterErroModelInvalida();
                return responseError;
            }
        }

        [HttpDelete]
        [Route("telefone/excluir")]
        [AllowAnonymous]
        public TelefoneViewModel Delete(Guid id)
        {
            telefoneAppService.Excluir(id);
            var telefone = new TelefoneViewModel();
            telefone.Messages = new List<string>();
            telefone.Messages.Add("Registro excluído com sucesso!");
            return telefone;
        }

        [HttpGet]
        [Route("telefone/listar")]
        [AllowAnonymous]
        public List<TelefoneViewModel> Get([FromQuery] int pagina, int tamanhoPagina)
        {
            return telefoneAppService.Listar(pagina, tamanhoPagina);
        }

        [HttpGet]
        [Route("telefone/obterPorId")]
        [AllowAnonymous]
        public TelefoneViewModel Get([FromQuery] Guid id)
        {
            return telefoneAppService.ObterPorId(id);
        }
    }
}
