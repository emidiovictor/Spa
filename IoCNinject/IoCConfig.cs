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

                /// Repository
                kernel.Bind<IClienteRepository>().To<ClienteRepository>();
                kernel.Bind<IFuncionarioRepository>().To<FuncionarioRespository>();
                kernel.Bind<ISalaoRepository>().To<SalaoRepository>();
                kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
                kernel.Bind<IFornecedorRepository>().To<FornecedorRepository>();

                /// APPSERVICE

                kernel.Bind<IFuncionarioAppService>().To<FuncionarioAppService>();
                kernel.Bind<IClienteAppSerivce>().To<ClienteAppSerivice>();
                kernel.Bind<ISalaoAppService>().To<SalaoAppSerivice>();
                kernel.Bind<IProdutoAppService>().To<ProdutoAppSevice>();
                kernel.Bind<IFornecedorAppService>().To<FornecedorAppSerivice>();


                /// OTHERS
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>();;
                kernel.Bind<Context>().To<Context>();;
                


                //Registra o container no ASP.NET
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            }
        }
    }
  

}