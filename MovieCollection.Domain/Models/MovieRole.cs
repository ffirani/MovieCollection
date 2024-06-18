using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class MovieRole:Entity
    {
        private string _name;
        public required string Name { get => _name; set => SetProperty<string>(ref _name, value, nameof(Name)); } 
    }
}
