using System.Collections.ObjectModel;

namespace netspecs.Tests.Fixtures
{
    public class UserRepository : ReadOnlyCollection<User>
    {
        public UserRepository()
            : base(new[]
            {
                new User { FavoriteNumber = 1, IsMale = true, Name = "Jorge Mario" },
                new User { FavoriteNumber = 2, IsMale = false, Name = "Maria Lucia" },
                new User { FavoriteNumber = 1, IsMale = true, Name = "John Lister" },
                new User { FavoriteNumber = 3, IsMale = true, Name = "Johny Pericles" }
            })
        {
        }
    }
}
