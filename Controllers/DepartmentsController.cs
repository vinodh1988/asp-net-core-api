using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private SQLiteDBContext _context;

        public DepartmentsController(SQLiteDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Get()
        {

            return await _context.departments.Include(d => d.Employees).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ActionResult<Department>>> Post(Department dept){
            try
            {
                Console.WriteLine(dept.Employees.Count);
                _context.departments.Add(dept);
                foreach (Employee x in dept.Employees)
                {
                    x.Dno = dept.Dno;
                }
                
                await _context.SaveChangesAsync();
                return Ok(dept);
            }
            catch (Exception e) { 
                return StatusCode(500, e.Message);
            }
         }
    }
}
