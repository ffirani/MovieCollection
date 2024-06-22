using MovieCollection.Query.View.Base;

namespace MovieCollection.Query.View
{
    public class PersonView : BaseView
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
