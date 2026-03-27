using HogRider.Backend.Data;
using HogRider.Backend.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogRider.Backend.Tests.Models
{
    public class ClientTests
    {
        [Fact]
        public void Can_Create_Client()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);

            Assert.Single(context.Clients);
        }
    }
}
