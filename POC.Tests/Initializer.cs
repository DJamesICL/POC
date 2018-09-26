using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using POC.Features;
using POC.Features.Pipelines;
using POC.Features.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POC.Tests
{
    class Initializer
    {
        #region Test Container

        public static IServiceProvider Initialize()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            serviceCollection.AddMediatR(new Assembly[]
            {
                typeof(POC.Features.Extensions).Assembly
            });

            serviceCollection.AddPOCFeatures();
            serviceCollection.AddPOCPipelines();

            containerBuilder.Populate(serviceCollection);

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        #endregion
    }
}
