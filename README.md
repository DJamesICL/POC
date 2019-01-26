POC

A simple Proof of Concept, demonstrating a technique to utilize a mediator to abstract away the infrastructure from business logic.

This example demonstrates business logic in shared Net Standard libraries, called from several different platforms:  Core Test, Core ASPNET, Service Fabric Controllers and Actors, and Console.

By utilizing IRequest<TResponse> queries and handlers, applications can simply serve as thin wrappers that delegate requests to the corresponding handlers.  Utilizing dependency-injection, the handlers and dependencies are resolved automatically as needed.  This abstraction can be generalized, so API endpoints can be easily changed, configured and automatically created by iterating the Queries and Handlers in an assembly.

I've also used this technique to automatically generate client sdk libraries as new features are added to API services.  Client libraries simply handle all requests in a familiar fashion, inspecting attributes or interfaces of the requests for AOP concerns (validation, routing, etc).  A request from the client can then be serialized, forwarded to a web api service, where the request is deserialized and converted back into a request object and forwarded to a handler capable of resolving the request.  The response is then sent back the same way.

Utilizing the IProgress<T> pattern and SignalR, I've also used this technique to create bi-directional communication between the client and handler.
