using LoadEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoadEntity
{
    public static class RegisterDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {

            services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            });
            var app = services.BuildServiceProvider();
            var dbcontext = app.GetService<PersonDbContext>();
            dbcontext.Database.Migrate();
            if (!dbcontext.Persons.Any())
            {
                dbcontext.Persons.Add(new PersonEntity
                {
                    Name = "Popescu Ion",
                    OwnBooks = new List<BookEntity>
                    {
                        new BookEntity
                        {
                            Title = "Ion",
                            Authors = new List<AuthorEntity>
                            {
                                new AuthorEntity
                                {
                                    Name = "Liviu Rebreanu"
                                }
                            }
                        }
                        ,
                        new BookEntity
                        {
                            Title = "Morometii",
                            Authors = new List<AuthorEntity>
                            {
                                new AuthorEntity
                                {
                                    Name = "Marin Preda"
                                },
                                new AuthorEntity
                                {
                                    Name = "Caragiale Impostoru"
                                }
                            }
                        }
                    }
                });
                dbcontext.SaveChanges();
            }
            app.Dispose();

            return services;
        }
    }
}
