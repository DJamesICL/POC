using POC.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC.Features.Services
{
    class DataService : IDataService
    {
        private List<Widget> Widgets;

        public DataService()
        {
            this.Widgets = new List<Widget>();
        }

        public Task<List<Widget>> GetAll()
        {
            return Task.FromResult( this.Widgets );
        }

        public Task Insert(Widget widget)
        {
            this.Widgets.Add(widget);
            return Task.CompletedTask;
        }
    }
}
