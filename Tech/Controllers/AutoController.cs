using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.InterTech;
using BackEnd.Models;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<AutoViewModel> autoViewModel = dbcontext.Autos.Include(p => p.Break).Select(p => new AutoViewModel() { Id = p.Id, Person =p.Person.SurnameNP, Brand = p.Brand.TitleBrand, Color = p.Color, DateStart = p.DateStart, RegNumer = p.RegNumer, Breaks = string.Join(',', p.Break.BreakName) }).ToList();

            return autoViewModel;
        }

        [HttpGet("Break")]
        public List<Break> GetBreaks()
        {

            return dbcontext.Break.ToList();

        }



        // POST api/<AutoController>
        [HttpPost]
        public void Post([FromForm] string titlebrand, [FromForm] string model, [FromForm] int idperson, [FromForm] string regNumber, [FromForm] string color, [FromForm] int dateStart, [FromForm] string Breaks)
        {

            dbcontext.Brands.Add(new Brand() { Model = model, TitleBrand = titlebrand });

            dbcontext.SaveChanges();
            int IdBrand = dbcontext.Brands.FirstOrDefault(p => p.Model == model && p.TitleBrand == titlebrand).id;
            



            Auto auto = new Auto() { };

            auto.Brand = dbcontext.Brands.FirstOrDefault(p=>p.id==IdBrand);
            auto.Person = dbcontext.Persons.FirstOrDefault(p=>p.Id==idperson);
            auto.Color = color;
            auto.RegNumer = regNumber;
            auto.DateStart = dateStart;
            auto.Break = dbcontext.Break.FirstOrDefault(p => p.BreakName == Breaks);



            dbcontext.Break.UpdateRange(dbcontext.Break);
            dbcontext.Autos.Add(auto);

            dbcontext.SaveChanges();


        }

        // PUT api/<AutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string brand, [FromForm] string person, [FromForm] string regnumber, [FromForm] string color, [FromForm] int datestart, [FromForm] string breaks)
        {
            Auto auto = dbcontext.Autos.Include(p => p.Break).Include(p=>p.Person).Include(p=>p.Brand).FirstOrDefault(p => p.Id == id);
            Brand brands = dbcontext.Brands.FirstOrDefault(p => p.id == auto.Brand.id);
            Person changeperson = dbcontext.Persons.FirstOrDefault(p => p.Id == auto.Person.Id);

            changeperson.SurnameNP = person;

            brands.TitleBrand = brand;
            dbcontext.Brands.Update(brands);
            dbcontext.Persons.Update(changeperson);
            dbcontext.SaveChanges();
            auto.Brand = dbcontext.Brands.FirstOrDefault(p => p.TitleBrand == brand);
            auto.Person = dbcontext.Persons.FirstOrDefault(p => p.SurnameNP == person);
            auto.RegNumer = regnumber;
            auto.Color = color;
            auto.DateStart = datestart;

            auto.Break = dbcontext.Break.FirstOrDefault(p => p.BreakName == breaks);


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
