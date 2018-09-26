using System;
using System.Diagnostics;
using System.Fabric;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.ServiceFabric;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Actors.Runtime;
using POC.Features;

namespace POC.ServiceFabric.POCActor
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
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

                containerBuilder.RegisterServiceFabricSupport();
                containerBuilder.RegisterActor<POCActor>();

                using (containerBuilder.Build())
                {
                    Thread.Sleep(Timeout.Infinite);
                }


               // var container = containerBuilder.Build();

             //   var p = new AutofacServiceProvider(container);

                // This line registers an Actor Service to host your actor class with the Service Fabric runtime.
                // The contents of your ServiceManifest.xml and ApplicationManifest.xml files
                // are automatically populated when you build this project.
                // For more information, see https://aka.ms/servicefabricactorsplatform

               // ActorRuntime.RegisterActorAsync<POCActor> (
               //    (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

               // Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
