using System.Data.Entity;

namespace netspecs.EF.Tests.Fixtures
{
    public class UserContext : DbContext
    {
        static UserContext()
        {
            Database.SetInitializer<UserContext>(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}