using LoadEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoadEntity
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
    }
}
