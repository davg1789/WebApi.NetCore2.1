using CadastroWebApi.Application.ViewModel;
using CadastroWebApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CadastroWebApi.Application.Mapper
{
    public static class Map
    {
        public static Pessoa MapperPessoaViewModelDomain(PessoaViewModel pessoaViewModel)
        {
            return new Pessoa(pessoaViewModel.IdPessoa, pessoaViewModel.Nome, pessoaViewModel.Cpf, pessoaViewModel.Rg);
        }

        public static PessoaViewModel MapperDomainPessoaViewModel(Pessoa pessoa)
        {
            if (pessoa == null) return null;

            var pessoaViewModel = new PessoaViewModel(pessoa.IdPessoa, pessoa.Nome, pessoa.CPF, pessoa.Rg);
            if(pessoa.Endereco != null)
            {
                pessoaViewModel.Endereco = MapperDomainEnderecoViewModel(pessoa.Endereco.FirstOrDefault());
            }

            if (pessoa.Telefone != null)
            {
                pessoaViewModel.Telefones = MapperDomainListTelefoneViewModelList(pessoa.Telefone);
            }

            return pessoaViewModel;
        }

        public static List<PessoaViewModel> MapperDomainListPessoaViewModelList(List<Pessoa> pessoas)
        {
            List<PessoaViewModel> pessoasViewModel = new List<PessoaViewModel>();
            PessoaViewModel pessoaViewModel = null;

            foreach (var item in pessoas)
            {
                pessoaViewModel = new PessoaViewModel();
                pessoaViewModel.Nome = item.Nome;
                pessoaViewModel.Cpf = item.CPF;
                pessoaViewModel.Rg = item.Rg;

                if(item.Endereco != null)
                {
                    pessoaViewModel.Endereco = MapperDomainListEnderecoViewModel(item.Endereco);
                }    
                
                if(item.Telefone != null)
                {
                    pessoaViewModel.Telefones = MapperDomainListTelefoneViewModelList(item.Telefone);
                }

                pessoasViewModel.Add(pessoaViewModel);
            }

            return pessoasViewModel;
        }

        public static Telefone MapperTelefoneViewModelDomain(TelefoneViewModel telefoneViewModel)
        {
            return new Telefone(telefoneViewModel.IdTelefone, telefoneViewModel.Tipo, telefoneViewModel.Numero, telefoneViewModel.IdPessoa);
        }

        public static TelefoneViewModel MapperDomainTelefoneViewModel(Telefone telefone)
        {
            if (telefone == null) return null;

            return new TelefoneViewModel(telefone.IdTelefone, telefone.Tipo, telefone.Numero, telefone.IdPessoa);
        }

        public static List<TelefoneViewModel> MapperDomainListTelefoneViewModelList(List<Telefone> telefones)
        {
            List<TelefoneViewModel> telefonesViewModel = new List<TelefoneViewModel>();
            TelefoneViewModel telefoneViewModel = null;

            foreach (var item in telefones)
            {
                telefoneViewModel = new TelefoneViewModel();
                telefoneViewModel.IdTelefone = item.IdTelefone;
                telefoneViewModel.Tipo = item.Tipo;
                telefoneViewModel.Numero = item.Numero;
                telefoneViewModel.IdPessoa = item.IdPessoa;

                telefonesViewModel.Add(telefoneViewModel);
            }

            return telefonesViewModel;
        }

        public static Endereco MapperEnderecoViewModelDomain(EnderecoViewModel enderecoViewModel)
        {
            return new Endereco(enderecoViewModel.IdEndereco, enderecoViewModel.Cep, enderecoViewModel.Logradouro,
                enderecoViewModel.Numero, enderecoViewModel.Bairro, enderecoViewModel.Municipio, enderecoViewModel.Uf
                ,enderecoViewModel.IdPessoa);
        }

        public static EnderecoViewModel MapperDomainEnderecoViewModel(Endereco endereco)
        {
            if (endereco == null) return null;

            return new EnderecoViewModel(endereco.IdEndereco, endereco.Cep, endereco.Logradouro, 
                endereco.Numero, endereco.Bairro, endereco.Municipio, endereco.Uf, endereco.IdPessoa);
        }

        public static EnderecoViewModel MapperDomainListEnderecoViewModel(List<Endereco> enderecos)
        {            
            EnderecoViewModel enderecoViewModel = null;

            foreach (var item in enderecos)
            {
                enderecoViewModel = new EnderecoViewModel();
                enderecoViewModel.Bairro = item.Bairro;
                enderecoViewModel.Cep = item.Cep;
                enderecoViewModel.IdEndereco = item.IdEndereco;
                enderecoViewModel.Logradouro = item.Logradouro;
                enderecoViewModel.Municipio = item.Municipio;
                enderecoViewModel.Numero = item.Numero;
                enderecoViewModel.Uf = item.Uf;
                enderecoViewModel.IdPessoa = item.IdPessoa;

                break; // para se adequar ao modelo que tem 1 endereço no json, não é array
            }

            return enderecoViewModel;
        }
    }
}
