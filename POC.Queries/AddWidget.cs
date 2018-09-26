using MediatR;
using POC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Queries
{
    public class AddWidget : IRequest
    {
        public string Name { get; set; }
    }
}
