using MovieCollection.Infrastructure.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db.Exception
{
    public class DatabaseException : AppException
    {
        public DatabaseException(string errorCode, string message) : base(errorCode, message)
        {
        }

        public DatabaseException(string errorCode, string message, System.Exception innerException ) : base(errorCode, message, innerException)
        {
        }
    }
}
