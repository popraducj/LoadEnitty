using System.ComponentModel.DataAnnotations.Schema;

namespace LoadEntity.Entities
{
    public class PersonEntity : BaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        public IList<BookEntity> OwnBooks { get; set; }
    }
}
