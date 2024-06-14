using MediatR;
using MovieCollection.API.Commands.Base;

namespace MovieCollection.API.Commands
{
    public class DeleteEntityCommand<TEntity> : IRequest,IDeleteEntityCommand
    {
        public Guid Id { get; set; }
    }
}
