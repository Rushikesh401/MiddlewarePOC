using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiddlewarePOC.Data;
using MiddlewarePOC.Models;

namespace MiddlewarePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public PersonController(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _dataContext.Persons.ToListAsync();
        }

        [HttpPost]

        public async Task<Person> Post(Person person)
        {
            if (person != null)
            {
                _dataContext.Persons.Add(person);
                await _dataContext.SaveChangesAsync();
                return person;
            }
            else
            {
                return null;
            }
        }
    }
}
