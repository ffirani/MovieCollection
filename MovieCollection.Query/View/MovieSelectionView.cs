using MovieCollection.Query.View.Base;

namespace MovieCollection.Query.View
{
    public class MovieSelectionView : BaseView
    {
        public required string Name { get; set; }
        public string Description { get; set; }
    }
}
