using System;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.ViewModels;
using UoW;

namespace Aplication.AppService
{
    public class FuncionarioAppService : AppServiceBase<Funcionario,FuncionarioViewModel> , IFuncionarioAppService
    {
        private readonly IFuncionarioRepository repository;
        public FuncionarioAppService(IFuncionarioRepository repository,
            IUnitOfWork unitOfWork, Context context):base(repository,unitOfWork,context)
        {
            this.repository = repository;
        }

        public FuncionarioViewModel GetFuncionarioEndereco(Guid? id)
        {
            return Mapper.Map<FuncionarioViewModel>(repository.GetFuncionarioEndereco(id));
        }
    }
}
