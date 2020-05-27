using Autofac;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.ViewModels;
using ProyectoXamarin.Views;

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

            
            builder.RegisterType<CarritoViewModel>();
            builder.RegisterType<CarouselViewModel>();
            builder.RegisterType<ComentariosViewModel>();

            builder.RegisterType<MainMotoresView>();
            container = builder.Build();
        }

        public CarouselViewModel CarouselViewModel
        {
            get { return this.container.Resolve<CarouselViewModel>(); }
        }
        public CarritoViewModel CarritoViewModel
        {
            get { return this.container.Resolve<CarritoViewModel>(); }
        }
        public ComentariosViewModel ComentariosViewModel
        {
            get { return this.container.Resolve<ComentariosViewModel>(); }
        }

        public MainMotoresView MainMotoresView
        {
            get { return this.container.Resolve<MainMotoresView>(); }
        }
    }
}
