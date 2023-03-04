
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id {get; set;}
        [Required]
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre {get; set;}
        public int MovieYear { get; set; }
        public int MovieCost { get; set; }
        public virtual ICollection<MovieActressActor> MovieActressActors { get; set; }
        public virtual ICollection<MoviesDirector> MovieDirectors { get; set; }
        
    }         
}