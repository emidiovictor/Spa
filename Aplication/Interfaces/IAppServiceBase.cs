using Domain.Entity;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;

namespace Aplication.Interfaces
{
    public interface IAppServiceBase<TEntity, ViewModel> : IDisposable
        where TEntity : Entity
        where ViewModel : ViewModelBase
    {
        ICollection<ViewModel> GetAll();
        ViewModel Get(Guid? id);
        void Add(ViewModel viewModel);
        void Update(ViewModel viewModel);
        void Delete(Guid? id);

    }
}
