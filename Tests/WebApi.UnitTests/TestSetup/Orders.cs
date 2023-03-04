using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.Orders.AddRange(
            new Order{});

        }
    }
}