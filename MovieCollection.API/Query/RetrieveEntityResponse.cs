using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityResponse<TView> where TView : BaseView
    {
        public TView View { get; set; }
    }
}
