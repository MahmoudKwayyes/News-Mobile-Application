using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace News
{
    public static class Bootstrapper
    {
        public static void Initilize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Services.NewsService>();
            containerBuilder.RegisterType<MainShell>();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(ViewModels.ViewModel)));
            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
