using MediatR;
using POC.Features.Services;
using POC.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Features.Pipelines
{
    public class StopWatchPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger Logger;

        public StopWatchPipeline(ILogger logger)
        {
            this.Logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken token, RequestHandlerDelegate<TResponse> next)
        {
            var sw = new Stopwatch();
            sw.Start();

            var result = await next.Invoke();

            sw.Stop();
            this.Logger.Log($"Handled [{typeof(TRequest).Name}] in {sw.ElapsedMilliseconds} ms.");

            return result;
        }
    }
}
