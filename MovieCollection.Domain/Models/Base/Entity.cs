using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get;set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
