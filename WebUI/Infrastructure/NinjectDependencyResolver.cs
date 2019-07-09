using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using Domain.Entities;
using Domain.Abstract;
using Domain.Concrete;
using WebUI.Infrastructure.Concrete;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type sericeType)
        {
            return _kernel.TryGet(sericeType);
        }

        public IEnumerable<object> GetServices(Type sericeType)
        {
            return _kernel.GetAll(sericeType);
        }

        public void AddBindings()
        {
            /*Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game { Name="SimCity", Price=1499},
                new Game { Name="TitanFall", Price=2299},
                new Game { Name="Battlefield 4", Price=899.4M}


            });
            _kernel.Bind<IGameRepository>().ToConstant(mock.Object);*/
            _kernel.Bind<IGameRepository>().To<EFGameRepository>();
            _kernel.Bind<IAuthProvider>().To<FormAuthProvider>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            _kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("emailSettings", emailSettings);

        }

    }
}