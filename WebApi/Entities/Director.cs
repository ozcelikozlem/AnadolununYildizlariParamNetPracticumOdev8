using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
        public virtual ICollection<MoviesDirector> MovieDirectors { get; set; }

    }
}