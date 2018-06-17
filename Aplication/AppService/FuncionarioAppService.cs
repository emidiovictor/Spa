using System;
using System.Data.Entity;
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

        public override FuncionarioViewModel Get(Guid? id)
        {
            return Mapper.Map<FuncionarioViewModel>(repository.GetFuncionarioEndereco(id));
        }
        public override void Update(FuncionarioViewModel viewModel)
        {
            var funcionario = Mapper.Map<Funcionario>(viewModel);
            _context.Set<Funcionario>().Attach(funcionario);
            _context.Entry(funcionario).State = EntityState.Modified;
            _context.Entry(funcionario.Endereco).State = EntityState.Modified;
            _unitOfWork.Commit();
        }
    }
}
