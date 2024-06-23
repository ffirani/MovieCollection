using MovieCollection.Query.View.Ref;

namespace MovieCollection.Query.View.Base
{
    public abstract class BaseView
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }
        public UserView Owner { get; set; }

        public Guid CreatedBy { get; set; }
        public UserView CreatedByUser { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid ModifiedBy { get; set; }
        public UserView ModifiedByUser { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
