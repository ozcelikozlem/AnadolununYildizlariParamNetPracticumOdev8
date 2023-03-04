using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class ActressActors
    {
        public static void AddActressActors(this MovieStoreDbContext context)
        {
            context.ActressActors.AddRange(
                    new ActressActor
                    {
                        ActressActorName ="Anne",
                        ActressActorSurname="Hathaway",
                    },
                    new ActressActor
                    {
                        ActressActorName ="Helena",
                        ActressActorSurname="Bonham Carter",
                    },
                    new ActressActor
                    {
                        ActressActorName ="John Christopher",
                        ActressActorSurname="Depp",
                    },
                    new ActressActor
                    {
                        ActressActorName =" Mark",
                        ActressActorSurname="Ruffalo",
                    },
                    new ActressActor
                    {
                        ActressActorName =" Benedict",
                        ActressActorSurname="Cumberbatch",
                    }
                );
        }
    }
}