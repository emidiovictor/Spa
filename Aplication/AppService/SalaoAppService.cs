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
    public class SalaoAppSerivice : AppServiceBase<Salao, SalaoViewModel>, ISalaoAppService
    {
        private readonly ISalaoRepository _repository;
        public SalaoAppSerivice(ISalaoRepository repository,
           IUnitOfWork unitOfWork, Context context) : base(repository, unitOfWork, context)
        {
            _repository = repository;
        }

        public void UpdateSalaoEndereco(SalaoViewModel salaoViewModel)
        {
            var salao = Mapper.Map<Salao>(salaoViewModel);
            _context.Set<Salao>().Attach(salao);
            _context.Entry(salao).State = EntityState.Modified;
            _context.Entry(salao.Endereco).State = EntityState.Modified;
            _unitOfWork.Commit();
        }


    }
}
