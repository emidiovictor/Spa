using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW;

namespace Aplication.AppService
{
    public class FornecedorAppSerivice : AppServiceBase<Fornecedor, FornecedorViewModel>, IFornecedorAppService
    {
        private readonly IFornecedorRepository _repository;
        public FornecedorAppSerivice(IFornecedorRepository repository,
           IUnitOfWork unitOfWork, Context context) : base(repository, unitOfWork, context)
        {
            _repository = repository;
        }

        public override FornecedorViewModel Get(Guid? id)
        {
            return Mapper.Map<FornecedorViewModel > (_repository.GetFornecedorEndereco(id));
        }
        public override void Update(FornecedorViewModel viewModel)
        {
            var fornecedor = Mapper.Map<Fornecedor>(viewModel);
            _context.Set<Fornecedor>().Attach(fornecedor);
            _context.Entry(fornecedor).State = EntityState.Modified;
            _context.Entry(fornecedor.Endereco).State = EntityState.Modified;
            _unitOfWork.Commit();
        }
    }
}
