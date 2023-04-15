using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace News
{
    public static class Resolver
    {
        public static IContainer Container;
        public static void Initialize(IContainer container)
        {
            Resolver.Container = container;
        }
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
