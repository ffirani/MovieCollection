using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class MovieSelection:Entity
    {
        private string _name;
        public required string Name { get=>_name; set => SetProperty<string>(ref _name, value, nameof(Name)); }

        private string _description;
        public string Description { get=>_description; set => SetProperty<string>(ref _description, value, nameof(Description)); }

    }
}
