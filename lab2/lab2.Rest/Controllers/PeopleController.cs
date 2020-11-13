using System;
using lab2.Rest.Context;
using lab2.Rest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly AzureDbContext context;

        public PeopleController(AzureDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var people = context.People.ToList();
            return people;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = new Person();
            return person;
        }

        [HttpPost]
        public void Post([FromBody] Person value)
        {
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person value)
        {
            
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
