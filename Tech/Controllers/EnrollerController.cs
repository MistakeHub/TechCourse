using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using BackEnd.InterTech;
using BackEnd.Models;
using BackEnd.Models.ViewModels;
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
        public List<EnrollerViewModel> Get()
        {
            List<EnrollerViewModel> enrollerViewModel = dbcontext.Enrollers.Select(p => new EnrollerViewModel()
            {
                Id = p.Id, Person = dbcontext.Persons.FirstOrDefault(d => d.Id == p.IdPerson).SurnameNP,
                Specialty = dbcontext.Specialties.FirstOrDefault(d => d.Id == p.IdSpecialty).TitleSpec,
                PeriodWork = p.PeriodWork, Level = p.Level,
                Status = dbcontext.Statuses.FirstOrDefault(d => d.Id == p.idStatus).status
            }).ToList();
            return enrollerViewModel;
        }

       

        // POST api/<EnrollerController>
        [HttpPost]
        public void Post([FromForm] int id, [FromForm] string titlespec, [FromForm] string surnameNP, [FromForm] string passport, [FromForm] int idSpeciality , [FromForm] string level, [FromForm] string periodWork, [FromForm] int idstatus)
        {
            dbcontext.Persons.Add(new Person() {SurnameNP = surnameNP, Passport = passport});
            dbcontext.SaveChanges();

            Enroller newEnroller=new Enroller(){ IdPerson = dbcontext.Persons.FirstOrDefault(p=>p.Passport==passport).Id, IdSpecialty = idSpeciality, Level = level, PeriodWork = periodWork, idStatus = idstatus};
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
