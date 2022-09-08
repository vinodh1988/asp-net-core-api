using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}

