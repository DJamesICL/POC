using MediatR;
using POC.Features.Services;
using POC.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Features
{
    class GetWidgetsHandler : IRequestHandler<GetWidgets, GetWidgetsResult>
    {
        private IDataService DataService;

        public GetWidgetsHandler(IDataService ds)
        {
            this.DataService = ds;
        }

        public async Task<GetWidgetsResult> Handle(GetWidgets request, CancellationToken cancellationToken)
        {
            var widgets = await this.DataService.GetAll();

            return new GetWidgetsResult
            {
                Widgets = widgets
            };
        }
    }
}
