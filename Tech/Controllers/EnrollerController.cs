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

        private TechDbContext dbcontext;

        public EnrollerController(TechDbContext _context)
        {
            dbcontext = _context;

        }
        [HttpGet]
        public List<Enroller> Get()
        {
            return dbcontext.Enrollers.ToList();
        }

       

        // POST api/<EnrollerController>
        [HttpPost]
        public void Post([FromForm] int id, [FromForm] int idSpeciality, [FromForm] int idPerson, [FromForm] string level, [FromForm] string periodWork, [FromForm] int idstatus)
        {
            Enroller newEnroller=new Enroller(){ IdPerson = idPerson, IdSpecialty = idSpeciality, Level = level, PeriodWork = periodWork, idStatus = idstatus};
            dbcontext.Enrollers.Add(newEnroller);
            dbcontext.SaveChanges();

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
