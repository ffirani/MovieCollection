using AutoMapper;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Commands.Dto
{
    [DomainEquivalent(typeof(Movie))]
    public class MovieDto
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseData { get; set; }

        public List<GenreDto>? Genres { get; set; }

        public List<CastAndCrewDto>? CastAndCrews { get; set; }
    }
}
