using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class MovieActressActor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }        
        public virtual Movie Movie { get; set; }
        public int ActressActorId { get; set; }
        public virtual ActressActor ActressActor { get; set; }
    }
}