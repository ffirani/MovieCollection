using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCollection.Domain.Models.Base;

namespace MovieCollection.Domain.Models
{
    public class MovieSelectionMovie : Entity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid MovieSelectionId { get; set; }
        public MovieSelection MovieSelection { get; set; }
    }
}
