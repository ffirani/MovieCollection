using MovieCollection.Query.View.Base;
using MovieCollection.Query.View.Ref;

namespace MovieCollection.Query.View
{
    public class CastAndCrewView:BaseView
    {
        public MovieRoleView Role { get; set; }

        public PersonView Person { get; set; }

        public MovieView Movie { get; set; }
    }
}
