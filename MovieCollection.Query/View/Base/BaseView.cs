using MovieCollection.Query.View.Ref;

namespace MovieCollection.Query.View.Base
{
    public class BaseView
    {
        public Guid Id { get; set; }

        public UserView Owner { get; set; }

        public UserView CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public UserView ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
