using CadastroWebApi.Application.AppServices;
using CadastroWebApi.Application.Interfaces;
using CadastroWebApi.Data.SqlServer.Context;
using CadastroWebApi.Data.SqlServer.Repository;
using CadastroWebApi.Domain.Interfaces.Repository;
using CadastroWebApi.Domain.Interfaces.Service;
using CadastroWebApi.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroWebApi.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {    

            // Application            
            services.AddScoped<IPessoaAppService, PessoaAppService>();
            services.AddScoped<ITelefoneAppService, TelefoneAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();
            

            // Domain - Services
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            // Infra - Data
            services.AddScoped<IRepositoryPessoa, RepositoryPessoa>();
            services.AddScoped<IRepositoryTelefone, RepositoryTelefone>();
            services.AddScoped<IRepositoryEndereco, RepositoryEndereco>();
            
            services.AddScoped<CadastroWebApiContext>();


        }
    }
}
