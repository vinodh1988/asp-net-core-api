using CrudAPI.Models;
using CrudAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPersonService Pservice;

        public PeopleController(IPersonService pservice)
        {
            Pservice = pservice;
        }

        [HttpGet]
        public IEnumerable<Person> Get() { 
            return this.Pservice.GetPeople();
        
        }
    }
}
