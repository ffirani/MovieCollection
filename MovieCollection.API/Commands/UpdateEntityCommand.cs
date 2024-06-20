using MediatR;
using MovieCollection.API.Commands.Base;

namespace MovieCollection.API.Commands
{
    public class UpdateEntityCommand<T>:IRequest
    {
        public required T Data { get; set; }
    }
}
