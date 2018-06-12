using AutoMapper;
using Domain.Entity;
using InfraData.ViewModels;

namespace Aplication.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ServicoViewModel, Servico>(MemberList.Source);
            CreateMap<ClienteViewModel, Clientes>().ForMember(x => x.Endereco, y => y.MapFrom(s => s.EnderecoViewModel));
            CreateMap<FuncionarioViewModel, Funcionario>().ForMember(x => x.Endereco, y => y.MapFrom(s => s.EnderecoViewModel));
            CreateMap<SalaoViewModel, Salao>().ForMember(x => x.Endereco, y => y.MapFrom(s => s.EnderecoViewModel));
            CreateMap<FornecedorViewModel, Fornecedor>().ForMember(x => x.Endereco, y => y.MapFrom(s => s.EnderecoViewModel));

        }
    }
}