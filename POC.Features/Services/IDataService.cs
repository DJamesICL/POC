using POC.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC.Features.Services
{
    public interface IDataService
    {
        Task<List<Widget>> GetAll();

        Task Insert(Widget widget);

    }
}
