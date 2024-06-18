using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Commands.Dto
{
    [DomainEquivalent(typeof(MovieRole))]
    public class MovieRoleDto
    {
        public string? Title { get; set; }
    }
}
