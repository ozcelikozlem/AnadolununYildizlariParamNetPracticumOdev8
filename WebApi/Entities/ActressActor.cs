using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities
{
    public class ActressActor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ActressActorName { get; set; }
        public string ActressActorSurname { get; set; }
        public virtual ICollection<MovieActressActor> MovieActressActors { get; set; }
    }
}