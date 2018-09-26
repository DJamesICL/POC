using MediatR;
using POC.Domain;
using System;
using System.Collections.Generic;

namespace POC.Queries
{
    public class GetWidgets : IRequest<GetWidgetsResult>
    {

    }

    public class GetWidgetsResult
    {
        public List<Widget> Widgets { get; set; }
    }
}
