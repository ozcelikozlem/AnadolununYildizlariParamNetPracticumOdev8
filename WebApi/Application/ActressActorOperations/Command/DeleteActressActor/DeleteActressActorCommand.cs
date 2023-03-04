using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActressActorOperations.Command.DeleteActressActor
{
    public class DeleteActressActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int Id;

        public DeleteActressActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            ActressActor actressActor = _context.ActressActors.SingleOrDefault(x => x.Id == Id);
            if (actressActor is null)
                throw new InvalidOperationException("this actress or actor not found.");

            _context.ActressActors.Remove(actressActor);
            _context.SaveChanges();
        }
    }
}