using MediatR;
using POC.Features.Services;
using POC.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Features
{
    public class AddWidgetHandler : IRequestHandler<AddWidget>
    {
        private IDataService DataService;

        public AddWidgetHandler(IDataService ds)
        {
            this.DataService = ds;
        }

        public async Task Handle(AddWidget request, CancellationToken cancellationToken)
        {
            var widget = new Domain.Widget
            {
                Name = request.Name
            };

            await this.DataService.Insert(widget);
        }
    }
}
