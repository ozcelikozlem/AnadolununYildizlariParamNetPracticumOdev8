using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.Customers.AddRange( 
                    new Customer
                    {
                        Name ="Özlem",
                        Surname="Özçelik",
                        Email="ozlm@gmail.com",
                        Password="1234"
                    }
                );
        }
    }
}