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
    public class ClienteAppSerivice : AppServiceBase<Clientes, ClienteViewModel>, IClienteAppSerivce
    {
        private readonly IClienteRepository _repository;
        public ClienteAppSerivice(IClienteRepository repository,
           IUnitOfWork unitOfWork, Context context) : base(repository, unitOfWork, context)
        {
            _repository = repository;
        }

        public override ClienteViewModel Get(Guid? id)
        {
            return Mapper.Map<ClienteViewModel>(_repository.GetClienteEndereco(id));
        }

        public void UpdateClienteEndereco(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Clientes>(clienteViewModel);
            _context.Set<Clientes>().Attach(cliente);
            _context.Entry(cliente).State = EntityState.Modified;
            _context.Entry(cliente.Endereco).State = EntityState.Modified;
            _unitOfWork.Commit();
        }
    }
}
