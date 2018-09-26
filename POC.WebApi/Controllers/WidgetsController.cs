using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace POC.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : Controller
    {
        private IMediator Mediator;

        public WidgetsController(IMediator mediator)
        {
            this.Mediator = mediator;
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
            await this.Mediator.Send(query, token);
            return Ok();
        }
    }
}
