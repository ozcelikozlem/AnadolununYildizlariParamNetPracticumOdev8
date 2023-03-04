using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
                    new Director
                    {
                        DirectorName ="Gore",
                        DirectorSurname="Verbinski",
                    },
                    new Director
                    {
                        DirectorName ="Louis",
                        DirectorSurname="Leterrier",
                    },
                    new Director
                    {
                        DirectorName ="Tim",
                        DirectorSurname="Burton",
                    },
                    new Director
                    {
                        DirectorName =" Gary",
                        DirectorSurname="Ross",
                    },
                    new Director
                    {
                        DirectorName =" Scott",
                        DirectorSurname="Derrickson",
                    }
                );
        }
    }
}