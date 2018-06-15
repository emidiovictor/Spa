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
    public class ProdutoAppSevice : AppServiceBase<Produto, ProdutoViewModel>,IProdutoAppService
    {
        public ProdutoAppSevice(IProdutoRepository repository, IUnitOfWork unitOfWork, Context context):base(repository,unitOfWork,context)
        {
                
        }
    }
}
