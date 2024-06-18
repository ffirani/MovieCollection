using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.Domain.Models.Base;

namespace MovieCollection.API.Commands
{
    public class CreateEntityCommand<TDto> : IRequest<CreateEntityResponse>
    {
        public required TDto Data { get; set; }
    }
}
