﻿using Aplication.Interfaces;
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
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly Context _context;

        public AppServiceBase(IRepository<TEntity> repository,
            IUnitOfWork unitOfWork, Context context)
        {
            _repository = repository;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public virtual ICollection<TViewModelBase> GetAll()
        {
            return Mapper.Map<ICollection<TViewModelBase>>(_repository.GetAll());
        }

        public virtual TViewModelBase Get(Guid? id)
        {
            return Mapper.Map<TViewModelBase>(_repository.Get(id));
        }

        public virtual void Add(TViewModelBase viewModel)
        {
            var entity = Mapper.Map<TEntity>(viewModel);
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(TViewModelBase viewModel)
        {
            var entity = Mapper.Map<TEntity>(viewModel);
            _repository.Add(entity);
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _unitOfWork.Commit();
        }

        public virtual void Delete(Guid? id)
        {
            var entity = Mapper.Map<TEntity>(_repository.Get(id));
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}