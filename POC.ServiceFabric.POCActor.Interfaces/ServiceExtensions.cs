using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.ServiceFabric.POCActor.Interfaces
{
    public static class ServiceExtensions
    {
        public static async Task<TResponse> Send<TResponse>(this IPOCActor actor, IRequest<TResponse> request, CancellationToken token)
        {
            var actorRequest = new ActorRequest
            {
                Type = request.GetType().AssemblyQualifiedName,
                Payload = JsonConvert.SerializeObject(request)
            };

            var actorResult = await actor.Send(actorRequest, token);

            var response = JsonConvert.DeserializeObject<TResponse>(actorResult.Payload);

            return response;
        }

        public static async Task<ActorResponse> Send(this IMediator m, ActorRequest request, CancellationToken token)
        {
            var requestType = Type.GetType(request.Type, true, true);
            var serviceRequest = JsonConvert.DeserializeObject(request.Payload, requestType);

            dynamic req = serviceRequest;

            var response = await m.Send(req);

            return new ActorResponse
            {
                Payload = JsonConvert.SerializeObject(response)
            };
        }
    }
}
