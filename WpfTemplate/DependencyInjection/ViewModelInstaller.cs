using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;

namespace WpfTemplate.DependencyInjection
{
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof(ViewModelInstaller))
                .Where(t => t.Name.EndsWith("ViewModel", StringComparison.Ordinal))
                .LifestyleTransient());
        }
    }
}
