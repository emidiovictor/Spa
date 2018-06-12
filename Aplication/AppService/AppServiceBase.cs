using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;
using UoW;

namespace Aplication.AppService
{
    public  class AppServiceBase<TEntity, TViewModelBase> : IAppServiceBase<TEntity, TViewModelBase>
        where TEntity : Entity, new()
        where TViewModelBase : ViewModelBase,new()

    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;

        public AppServiceBase(IRepository<TEntity> repository,
            IUnitOfWork unitOfWork, Context context)
        {
            _repository = repository;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public ICollection<TViewModelBase> GetAll()
        {
            return Mapper.Map<ICollection<TViewModelBase>>(_repository.GetAll());
        }

        public TViewModelBase Get(Guid? id)
        {
            return Mapper.Map<TViewModelBase>(_repository.Get(id));
        }

        public void Add(TViewModelBase viewModel)
        {
            var entity = Mapper.Map<TEntity>(viewModel);
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Update(TViewModelBase viewModel)
        {
            var entity = Mapper.Map<TEntity>(viewModel);
            _repository.Add(entity);
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _unitOfWork.Commit();
        }

        public void Delete(Guid? id)
        {
            var entity = Mapper.Map<TEntity>(_repository.Get(id));
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
#warning impementar dispoable;
        }

       
    }
}