using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.InterTech;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollerController : ControllerBase
    {
        // GET: api/<EnrollerController>

        private TechDbContext context;

        public EnrollerController(TechDbContext _context)
        {
            context = _context;

        }
        [HttpGet]
        public List<Enroller> Get()
        {
            return context.Enrollers.ToList();
        }

        // GET api/<EnrollerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnrollerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnrollerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnrollerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
