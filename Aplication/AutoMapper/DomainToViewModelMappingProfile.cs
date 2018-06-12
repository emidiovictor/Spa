using System;
using AutoMapper;
using Domain.Entity;
using InfraData.ViewModels;

namespace Aplication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Clientes, ClienteViewModel>().ForMember(x => x.EnderecoViewModel, y => y.MapFrom(s => s.Endereco));
            CreateMap<Funcionario, FuncionarioViewModel>().ForMember(x => x.EnderecoViewModel, y => y.MapFrom(s => s.Endereco));
            CreateMap<Salao, SalaoViewModel>().ForMember(x => x.EnderecoViewModel, y => y.MapFrom(s => s.Endereco));
            CreateMap<Fornecedor, FornecedorViewModel>().ForMember(x => x.EnderecoViewModel, y => y.MapFrom(s => s.Endereco));

        }
    }
}
