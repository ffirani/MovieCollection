using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class User:Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
