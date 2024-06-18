using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class Genre:Entity
    {
        public required string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
