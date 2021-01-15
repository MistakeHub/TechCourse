using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AutoController : ControllerBase
    {

        private TechDbContext dbcontext;

        public AutoController(TechDbContext context)
        {

            dbcontext = context;

        }
        // GET: api/<AutoController>
        [HttpGet]
        public List<AutoViewModel> Get()
        {
            List<AutoViewModel> autoViewModel=dbcontext.Autos.Select(p=>new AutoViewModel(){Id = p.Id, Person = dbcontext.Persons.FirstOrDefault(d=>d.Id==p.IdPerson).SurnameNP, Brand = dbcontext.Brands.FirstOrDefault(d=>d.id==p.IdBrand).TitleBrand, Color = p.Color, DateStart = p.DateStart, RegNumer = p.RegNumer}).ToList();
            return autoViewModel;
        }

      

        // POST api/<AutoController>
        [HttpPost]
        public void Post([FromForm] string titlebrand, [FromForm]string model, [FromForm] int idperson, [FromForm]string regNumber, [FromForm]string color, [FromForm] int dateStart  )
        {

            this.dbcontext.Brands.Add(new Brand() {Model = model, TitleBrand = titlebrand});
         
            dbcontext.SaveChanges();
            int IdBrand = dbcontext.Brands.FirstOrDefault(p => p.Model == model && p.TitleBrand == titlebrand).id;
               int IPerson=dbcontext.Persons.FirstOrDefault(p => p.Id == idperson).Id;
               
            dbcontext.Autos.Add(new Auto()
            {
                IdBrand = IdBrand,
                IdPerson = IPerson, Color = color,
                RegNumer = regNumber, DateStart = dateStart
            });

            dbcontext.SaveChanges();


        }

        // PUT api/<AutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string brand, [FromForm] string person, [FromForm] string regnumber, [FromForm] string color, [FromForm] int datestart)
        {
            Auto auto = dbcontext.Autos.FirstOrDefault(p => p.Id == id);
            Brand brands = dbcontext.Brands.FirstOrDefault(p => p.id == auto.IdBrand);
            Person changeperson = dbcontext.Persons.FirstOrDefault(p => p.Id == auto.IdPerson);
            changeperson.SurnameNP = person;

            brands.TitleBrand = brand;
            dbcontext.Brands.Update(brands);
            dbcontext.Persons.Update(changeperson);
            dbcontext.SaveChanges();
            auto.IdBrand = dbcontext.Brands.FirstOrDefault(p => p.TitleBrand == brand).id;
            auto.IdPerson = dbcontext.Persons.FirstOrDefault(p => p.SurnameNP == person).Id;
            auto.RegNumer = regnumber;
            auto.Color = color;
            auto.DateStart = datestart;
            dbcontext.Autos.Update(auto);
            dbcontext.SaveChanges();

        }

        // DELETE api/<AutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
