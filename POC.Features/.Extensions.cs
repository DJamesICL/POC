using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

 using System.Runtime.CompilerServices;
using POC.Features.Services;
using POC.Features.Pipelines;
using MediatR;

[assembly: InternalsVisibleTo("POC.Tests")]

namespace POC.Features
{   

    public static class Extensions
    {
        public static void AddPOCFeatures(this IServiceCollection services)
        {
            services.AddTransient<ILogger, Logger>();
            services.AddSingleton<IDataService, DataService>();
        }

        public static void AddPOCPipelines(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StopWatchPipeline<,>));
        }
    }
}
