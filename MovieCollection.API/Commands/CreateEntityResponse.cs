namespace MovieCollection.API.Commands
{
    public class CreateEntityResponse
    {
        public Guid Id { get; }

        public CreateEntityResponse(Guid id)
        {
            Id = id;
        }
    }
}
