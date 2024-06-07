using MediatR;

namespace MovieCollection.API.Commands.Base
{
    public interface ICreateEntityCommand:IRequest<CreateEntityResponse>
    {
    }
}
