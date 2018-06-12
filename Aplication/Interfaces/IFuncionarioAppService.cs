using Domain.Entity;
using InfraData.ViewModels;
using System;

namespace Aplication.Interfaces
{

    public interface IFuncionarioAppService : IAppServiceBase<Funcionario, FuncionarioViewModel>
    {
        FuncionarioViewModel GetFuncionarioEndereco(Guid? id);
    }
}
