using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BackEnd.InterTech;
using BackEnd.Models;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
                Id = p.Id,
                Person = dbcontext.Persons.FirstOrDefault(d => d.Id == p.Person.Id).SurnameNP,
                Specialty = dbcontext.Specialties.FirstOrDefault(d => d.Id == p.Specialty.Id).TitleSpec,
                PeriodWork = p.PeriodWork,
                Level = p.Level,
                Status = dbcontext.Statuses.FirstOrDefault(d => d.Id == p.Status.Id).status
            }).ToList();
            return enrollerViewModel;
        }



        [HttpGet]
        [Route("Speciality")]
        public List<Specialty> GetSpecialties()
        {

            return dbcontext.Specialties.ToList();

        }

        [HttpGet]
        [Route("Status")]
        public List<Status> GetStatuses()
        {

            return dbcontext.Statuses.ToList();

        }

        // POST api/<EnrollerController>
        [HttpPost]

        public void Post([FromForm] string surnameNP, [FromForm] string passport, [FromForm] string Speciality, [FromForm] string level, [FromForm] string periodWork, [FromForm] string street, [FromForm] int apartament, [FromForm] string home, [FromForm] DateTime date)
        {
            dbcontext.Persons.Add(new Person() { SurnameNP = surnameNP, Passport = passport , Address = new Address() { Apartament = apartament, Home = home, Street = street}, DateBirth = date});
            dbcontext.SaveChanges();
          
          
            string Level = level;
            string PeriodWork = periodWork;
        
            Enroller newEnroller = new Enroller()
            {
                Person = dbcontext.Persons.FirstOrDefault(p => p.Passport == passport),
                Specialty = dbcontext.Specialties.FirstOrDefault(p => p.TitleSpec == Speciality),
                Level = Level,
                PeriodWork = PeriodWork,
                Status = dbcontext.Statuses.FirstOrDefault(p => p.status == "Свободен")
            };
            dbcontext.Enrollers.Add(newEnroller);
            dbcontext.SaveChanges();

        }

        // PUT api/<EnrollerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string speciality, [FromForm] string person, [FromForm] string level, [FromForm] string periodwork, [FromForm] string status)
        {
            Enroller enroller = dbcontext.Enrollers.Include(p=>p.Person).Include(p=>p.Status).FirstOrDefault(p => p.Id == id);
            enroller.Specialty = dbcontext.Specialties.FirstOrDefault(p => p.TitleSpec == speciality);
            Person changeperson = dbcontext.Persons.FirstOrDefault(p => p.Id == enroller.Person.Id);
            changeperson.SurnameNP = person;
            dbcontext.Persons.Update(changeperson);
            dbcontext.SaveChanges();
            enroller.Person = dbcontext.Persons.FirstOrDefault(p => p.SurnameNP == changeperson.SurnameNP);
            enroller.Level = level;
            enroller.PeriodWork = periodwork;
            enroller.Status = dbcontext.Statuses.FirstOrDefault(p => p.status == status);
            dbcontext.Enrollers.Update(enroller);

            dbcontext.SaveChanges();
        }

        // DELETE api/<EnrollerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Enroller enroller = dbcontext.Enrollers.FirstOrDefault(p => p.Id == id);

            RequestForFix request = dbcontext.Requests.FirstOrDefault(p => p.Enroller.Id == id);
            if (request != null)
            {

                request.Enroller = dbcontext.Enrollers.FirstOrDefault(p => p.Id > 0);
                Enroller newenroller = dbcontext.Enrollers.FirstOrDefault(p => p.Id > request.Enroller.Id);
                newenroller.Status = dbcontext.Statuses.FirstOrDefault(p => p.status == "Занят");
                dbcontext.Enrollers.Update(newenroller);
                dbcontext.Requests.Update(request);
            }

            dbcontext.Enrollers.Remove(enroller);
            dbcontext.SaveChanges();



        }
    }
}
