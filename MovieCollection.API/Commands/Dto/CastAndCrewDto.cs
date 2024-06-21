using MovieCollection.Domain.Models;

namespace MovieCollection.API.Commands.Dto
{
    public class CastAndCrewDto
    {
        public required Guid RoleId { get; set; }
        public required Guid PersonId { get; set; }
        public required Guid MovieId { get; set; }
    }
}
