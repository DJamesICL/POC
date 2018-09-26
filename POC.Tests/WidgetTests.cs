using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.Features.Services;

namespace POC.Tests
{
    [TestClass]
    public class WidgetTests
    {
        private IMediator Mediator;
        private IServiceProvider Services;
        
        [TestInitialize]
        public void Initialize()
        {
            this.Services = Initializer.Initialize();
            this.Mediator = this.Services.GetService<IMediator>();
        }
        
        [TestMethod]
        public async Task TestAddWidget()
        {            
            var result = await this.Mediator.Send(new Queries.GetWidgets());

            Assert.AreEqual(result.Widgets.Count, 0);

            await this.Mediator.Send(new Queries.AddWidget { Name = "Test Widget" });

            result = await this.Mediator.Send(new Queries.GetWidgets());

            Assert.AreEqual(result.Widgets.Count, 1);
        }

        [TestMethod]
        public async Task TestSayHello()
        {
            var result = await this.Mediator.Send(new Queries.SayHello());

            Assert.AreEqual(result, "Hello!");
        }
    }
}
