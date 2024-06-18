using MovieCollection.Domain.Models;

namespace MovieCollection.API.Commands.Dto
{
    public class CastAndCrewDto
    {
        public required MovieRoleDto Role { get; set; }
        public required PersonDto Person { get; set; }
        public required MovieDto Movie { get; set; }
    }
}
