using MovieCollection.API.Commands.Base;

namespace MovieCollection.API.Commands
{
    public class UpdateEntityCommand<T>:IUpdateEntityCommand
    {
        public required T Data { get; set; }
    }
}
