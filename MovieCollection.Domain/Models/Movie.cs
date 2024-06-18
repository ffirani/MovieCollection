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
        private string _title;
        public string Title { get => _title; set => SetProperty<string>(ref _title, value, nameof(Title)); }

        private DateTime? _releaseData;
        public DateTime? ReleaseData 
        { 
            get=> _releaseData; 
            set=>SetProperty<DateTime?>(ref _releaseData, value, nameof(ReleaseData)); 
        }

        private decimal _imdbRate;
        public decimal ImdbRate { get => _imdbRate; set => SetProperty<decimal>(ref _imdbRate, value, nameof(ImdbRate)); }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<CastAndCrew> CastAndCrews { get; set; }
    }
}
