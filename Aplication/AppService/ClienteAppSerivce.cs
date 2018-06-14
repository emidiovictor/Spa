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
    public class ClienteAppSerivice : AppServiceBase<Clientes, ClienteViewModel> , IClienteAppSerivce
    {
        private readonly IClienteRepository _repository;
        public ClienteAppSerivice(IClienteRepository repository,
           IUnitOfWork unitOfWork, Context context) : base( repository, unitOfWork, context)
        {
            _repository = repository;
        }

        public ClienteViewModel GetFuncionarioEndereco(Guid id)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
