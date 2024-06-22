using MovieCollection.Query.View.Base;

namespace MovieCollection.Query.View
{
    public class MovieView : BaseView
    {
        public string Title { get; set; }
        public DateTime? ReleaseData { get; set; }  
        public decimal ImdbRate { get; set; }
    }
}
