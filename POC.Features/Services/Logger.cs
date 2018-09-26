using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Features.Services
{
    class Logger : ILogger
    {
        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
