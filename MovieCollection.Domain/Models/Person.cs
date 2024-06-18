using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models
{
    public class Person:Entity
    {
        private string _firstName;
        public required string FirstName { get=>_firstName; set=>SetProperty<string>(ref _firstName,value,nameof(FirstName)); }

        private string _lastName;
        public required string LastName { get => _lastName; set => SetProperty<string>(ref _lastName, value, nameof(LastName)); }

        private DateTime? _birthDate;
        public DateTime? BirthDate { get=>_birthDate; set => SetProperty<DateTime?>(ref _birthDate, value, nameof(BirthDate)); }


        public  ICollection<CastAndCrew> CastAndCrews { get; set; }
    }
}
