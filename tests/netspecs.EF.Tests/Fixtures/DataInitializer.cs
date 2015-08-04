using System.Data.Entity;

namespace netspecs.EF.Tests.Fixtures
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Users.Add(new User { FavoriteNumber = 1, IsMale = true, Name = "Jorge Mario" });
            context.Users.Add(new User { FavoriteNumber = 2, IsMale = false, Name = "Maria Lucia" });
            context.Users.Add(new User { FavoriteNumber = 1, IsMale = true, Name = "John Lister" });
            context.Users.Add(new User { FavoriteNumber = 3, IsMale = true, Name = "Johny Pericles" });
        }
    }
}
