namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityResponse<TView>
    {
        public IEnumerable<TView> Entities { get; set; }
        public int TotalNumber { get; set; }

    }
}
