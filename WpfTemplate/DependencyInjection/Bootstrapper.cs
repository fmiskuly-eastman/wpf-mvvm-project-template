using Castle.Windsor;
using Castle.Windsor.Installer;
using System;

namespace WpfTemplate.DependencyInjection
{
    public static class Bootstrapper
    {
        private static IWindsorContainer container;
        private static object syncRoot = new object();

        public static IWindsorContainer Container
        {
            get
            {
                if (container != null)
                {
                    return container;
                }

                lock (syncRoot)
                {
                    if (container == null)
                    {
                        var assem = FromAssembly
                            .Containing(typeof(Bootstrapper));
                        container = new WindsorContainer()
                            .Install(assem);
                    }
                    return container;
                }
            }
        }
    }
}
