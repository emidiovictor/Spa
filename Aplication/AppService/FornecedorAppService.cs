using Aplication.Interfaces;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;
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

    }
}
