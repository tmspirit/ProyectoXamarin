using Autofac;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.ViewModels;

namespace ProyectoXamarin.Services
{
    public class ServiceDependency
    {
        private IContainer container;
        public ServiceDependency()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<RepositoryMotores>();
            builder.RegisterType<CarouselViewModel>();
            container = builder.Build();
        }

        public CarouselViewModel CarouselViewModel
        {
            get { return this.container.Resolve<CarouselViewModel>(); }
        }
    }
}
