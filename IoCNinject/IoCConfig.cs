using Aplication.AppService;
using Aplication.Interfaces;
using Domain.Interfaces;
using InfraData.Repositories;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UoW;

namespace Poo3.App_Start
{
    public class IoCConfig
    {
        public class NinjectDependencyResolver : IDependencyResolver
        {
            private readonly IResolutionRoot _resolutionRoot;

            public NinjectDependencyResolver(IResolutionRoot kernel)
            {
                _resolutionRoot = kernel;
            }

            public object GetService(Type serviceType)
            {
                return _resolutionRoot.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _resolutionRoot.GetAll(serviceType);
            }
            public static void ConfigurarDependencias()
            {
                //Cria o Container 
                IKernel kernel = new StandardKernel();

                kernel.Bind<Context>().To<Context>();
                kernel.Bind<IClienteRepository>().To<ClienteRepository>();
                kernel.Bind<IFuncionarioRepository>().To<FuncionarioRespository>();
                kernel.Bind<ISalaoRepository>().To<SalaoRepository>();
                kernel.Bind<IFuncionarioAppService>().To<FuncionarioAppService>();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>();


                //Registra o container no ASP.NET
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            }
        }
    }
  

}