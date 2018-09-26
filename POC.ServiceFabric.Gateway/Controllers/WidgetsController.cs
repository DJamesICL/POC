using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using POC.ServiceFabric.POCActor.Interfaces;

namespace POC.ServiceFabric.Gateway.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : Controller
    {
        IPOCActor Mediator;

        public WidgetsController()
        {
            this.Mediator = ActorProxy.Create<IPOCActor>(new ActorId(Guid.NewGuid()));
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await this.Mediator.Send(new Queries.GetWidgets(), token);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("Hello")]
        public async Task<IActionResult> SayHello(CancellationToken token)
        {
            var result = await this.Mediator.Send(new Queries.SayHello(), token);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Queries.AddWidget query, CancellationToken token)
        {
            var result = await this.Mediator.Send(query, token);
            return Ok(result);
        }
    }
}
