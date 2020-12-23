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
    public class AutoController : ControllerBase
    {

        private TechDbContext dbcontext;

        public AutoController(TechDbContext context)
        {

            dbcontext = context;

        }
        // GET: api/<AutoController>
        [HttpGet]
        public List<Auto> Get()
        {
            return dbcontext.Autos.ToList();
        }

      

        // POST api/<AutoController>
        [HttpPost]
        public void Post([FromForm] string titlebrand, [FromForm]string model, [FromForm] string passport, [FromForm] string surnameNP, [FromForm]string regNumber, [FromForm]string color, [FromForm] int dateStart  )
        {

            dbcontext.Brands.Add(new Brand() {Model = model, TitleBrand = titlebrand});
            dbcontext.Persons.Add(new Person() {Passport = passport, SurnameNP = surnameNP});
            dbcontext.SaveChanges();
            dbcontext.Autos.Add(new Auto()
            {
                IdBrand = dbcontext.Brands.FirstOrDefault(p => p.Model == model && p.TitleBrand == titlebrand).id,
                IdPerson = dbcontext.Persons.FirstOrDefault(p => p.Passport == passport).Id, Color = color,
                RegNumer = regNumber, DateStart = dateStart
            });

            dbcontext.SaveChanges();


        }

        // PUT api/<AutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
