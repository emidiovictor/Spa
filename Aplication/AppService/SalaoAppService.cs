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
    public class SalaoAppSerivice : AppServiceBase<Salao, SalaoViewModel>, ISalaoAppService
    {
        private readonly ISalaoRepository _repository;
        public SalaoAppSerivice(ISalaoRepository repository,
           IUnitOfWork unitOfWork, Context context) : base(repository, unitOfWork, context)
        {
            _repository = repository;
        }


    }
}
