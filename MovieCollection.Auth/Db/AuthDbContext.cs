using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Auth.Db
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        {

        }
    }
}
