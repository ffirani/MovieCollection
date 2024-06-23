using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityResponse<TView> where TView : BaseView
    {
        public IEnumerable<TView> Entities { get; set; }
        public int TotalNumber { get; set; }

    }
}
