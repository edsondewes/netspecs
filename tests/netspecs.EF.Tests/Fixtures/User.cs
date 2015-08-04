using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netspecs.EF.Tests.Fixtures
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int FavoriteNumber { get; set; }
        public bool IsMale { get; set; }
        public string Name { get; set; }
    }
}
