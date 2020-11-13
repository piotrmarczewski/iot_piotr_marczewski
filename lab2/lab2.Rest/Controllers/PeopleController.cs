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
            var person = context.People.Single(p => p.PersonId == id);
            return person;
        }

        [HttpPost]
        public void Post([FromBody] Person value)
        {
            var people = context.Set<Person>();
            people.Add(value);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person value)
        {
            var existingPerson = context.People.Where(p => p.PersonId == id).FirstOrDefault<Person>();

            if (existingPerson != null)
            {
                existingPerson.FirstName = value.FirstName;
                existingPerson.LastName = value.LastName;

                context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingPerson = context.People.Where(p => p.PersonId == id).FirstOrDefault<Person>();
            if (existingPerson != null)
            {
                context.Remove(existingPerson);
                context.SaveChanges();
            }
        }
    }
}
