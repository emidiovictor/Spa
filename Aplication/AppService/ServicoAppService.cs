using Aplication.Interfaces;
using Domain.Entity;
using InfraData.Repositories;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW;

namespace Aplication.AppService
{
    public class ServicoAppService : AppServiceBase<Servico,ServicoViewModel>, IServicoAppService
    {
        public ServicoAppService(ServicoRepository repository,IUnitOfWork unitOfWork, Context context):
            base(repository,unitOfWork,context)
        {

        }
    }
}
