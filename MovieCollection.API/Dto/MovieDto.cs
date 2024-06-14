using AutoMapper;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Dto
{
    [DomainEquivalent(typeof(Movie))]
    public class MovieDto
    {
        public string Title { get; set; }
        public DateTime ReleaseData { get; set; }
    }
}
