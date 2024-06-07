using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public DateTime ProductionYear { get; set; }
    }
}
