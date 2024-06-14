namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityResponse<T>
    {
        public IEnumerable<T> Entities { get; set; }
        public int TotalNumber { get; set; }

    }
}
