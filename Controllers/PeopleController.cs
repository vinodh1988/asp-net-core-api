using CrudAPI.Models;
using CrudAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet("{sno}")]
        public ActionResult<Person> Get(int sno) {
            Person p=this.Pservice.Get(sno);
            try
            {
                if (p == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, new { message = "No such record exists" });
                }
                return p;
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something wrong" });
            }
     
        }

        [HttpPost]
        public ActionResult<Person> Post(Person person) {
            if (person.Name == null || person.Name.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Name is not valid" });

            if (person.City == null || person.City.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "City is not valid" });

             Pservice.Add(person);
            return StatusCode(StatusCodes.Status201Created, person);



        }
    }
}
