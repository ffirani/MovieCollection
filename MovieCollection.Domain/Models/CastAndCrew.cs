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
        public required Person Person { get; set; }
        public required Movie Movie { get; set; }
    }
}
