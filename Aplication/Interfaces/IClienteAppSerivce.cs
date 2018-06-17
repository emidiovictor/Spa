using Domain.Entity;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IClienteAppSerivce : IAppServiceBase<Clientes, ClienteViewModel>
    {
        void UpdateClienteEndereco(ClienteViewModel clienteViewModel);
    }
}
