using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class MoviesDirector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }        
        public virtual Movie Movie { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
    }
}