using System.Windows;
using System.Windows.Controls;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace WpfTemplate.DependencyInjection
{
    public class ViewInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container,
            IConfigurationStore store)
        {
            var classes = Classes
                .FromAssemblyContaining(typeof(ViewInstaller))
                .BasedOn<Window>()
                .OrBasedOn(typeof(Page))
                .LifestyleTransient();
            container.Register(classes);
        }
    }
}