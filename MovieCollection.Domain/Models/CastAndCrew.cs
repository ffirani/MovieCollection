using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class CastAndCrew:Entity
    {
        public Guid RoleId { get; set; }
        public  MovieRole Role { get; set; }

        public Guid PersonId { get; set; }
        public  Person Person { get; set; }

        public Guid MovieId { get; set; }
        public  Movie Movie { get; set; }
    }
}
