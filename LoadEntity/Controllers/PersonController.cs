using LoadEntity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoadEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext personDbContext;

        public PersonController(PersonDbContext personDbContext)
        {
            this.personDbContext = personDbContext;
        }
        [HttpGet]
        public async Task<IList<PersonEntity>> GetAsync()
        {
            var results = await personDbContext.Persons.Include(x => x.OwnBooks).ThenInclude(x => x.Authors).ToListAsync();
           
            return results;
        }
    }
}
