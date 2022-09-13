using CrudAPI.Helpers;
using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleDBController : ControllerBase
    {
        private SQLiteDBContext _context;

        public PeopleDBController(SQLiteDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {

            return await _context.people.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Person>>> Post(Person person)
        {

            _context.Add(person);

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, person);
            }

            catch (DbUpdateException) {
                if (PersonExists(person.Sno))
                    return Conflict();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Server Error"
                    });
            }
        }

        private bool PersonExists(int id) {
            return _context.people.Any(e => e.Sno == id);
        }
    }
}

