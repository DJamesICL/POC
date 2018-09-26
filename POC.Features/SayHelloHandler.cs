using MediatR;
using POC.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Features
{
    class SayHelloHandler :  IRequestHandler<SayHello, string>
    {
        public Task<string> Handle(SayHello request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Hello!");
        }
    }
}
