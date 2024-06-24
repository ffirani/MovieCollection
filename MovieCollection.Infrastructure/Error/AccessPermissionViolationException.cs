namespace MovieCollection.Infrastructure.Error
{
    public class AccessPermissionViolationException : AppException
    {
        public AccessPermissionViolationException(string errorCode, string message) : base(errorCode, message)
        {
        }
    }
}
