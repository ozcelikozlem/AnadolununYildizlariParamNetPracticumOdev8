using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActressActorOperations.Command.UpdateActressActor
{
    public class UpdateActressActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public UpdateActressActorModel Model;
        public int Id;

        public UpdateActressActorCommand(IMovieStoreDbContext context)
        {
            _context = context;            
        }

        public void Handle()
        {
            ActressActor actressActor = _context.ActressActors.SingleOrDefault(x=> x.Id == Id);
            if(actressActor is null)
                throw new InvalidOperationException("This actress or actor not found.");
            
            actressActor.ActressActorName = actressActor.ActressActorName == default ? actressActor.ActressActorName : Model.ActressActorName;
            actressActor.ActressActorSurname = actressActor.ActressActorSurname == default ? actressActor.ActressActorSurname : Model.ActressActorSurName;

            _context.ActressActors.Update(actressActor);
            _context.SaveChanges();
        }
    }

    public class UpdateActressActorModel
    {
        public string ActressActorName { get; set; }
        public string ActressActorSurName { get; set; }
    }
    
}