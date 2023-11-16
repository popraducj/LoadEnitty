namespace LoadEntity.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; }
        public IList<PersonEntity> Persons { get; set; }
        public IList<AuthorEntity> Authors { get; set; }
    }
}
