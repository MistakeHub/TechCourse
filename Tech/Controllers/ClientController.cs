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
    public class ClientController : ControllerBase
    {
        private TechDbContext dbcontext;

        public ClientController(TechDbContext context)
        {
            
                dbcontext = context;

        }
        // GET: api/<ClientController>
        [HttpGet]
        public List<Client> Get()
        {
            return dbcontext.Clients.ToList();
        }

        

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromForm] int idPerson, [FromForm]int idAddress, [FromForm]int year , [FromForm]int mounth, [FromForm]int day, [FromForm]string phonenumber)
        {
            Client newClient=new Client(){ IdPerson = idPerson, IdAddress = idAddress, DateBirth = new DateTime(year, mounth, day),PhoneNumber = phonenumber};
            dbcontext.Clients.Add(newClient);
            dbcontext.SaveChanges();
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public void Put([FromForm] int id, [FromForm] int idperson, [FromForm] string Surname, [FromForm] int idAddress, [FromForm] string street, [FromForm] string home, [FromForm] int apartament, [FromForm] string phonenumber )
        {
            Client changeClient = dbcontext.Clients.FirstOrDefault(p => p.Id == id);

            Person changeperson = dbcontext.Persons.FirstOrDefault(p => p.Id == idperson);
            changeperson.SurnameNP = Surname;
            dbcontext.Persons.Update(changeperson);
            Address changeAddress = dbcontext.Addresses.FirstOrDefault(p => p.Id == idAddress);
            changeAddress.Street = street;
            changeAddress.Home = home;
            changeAddress.Apartament = apartament;
            dbcontext.Addresses.Update(changeAddress);
            changeClient.PhoneNumber = phonenumber;
            dbcontext.Clients.Update(changeClient);
            dbcontext.SaveChanges();



        }

        // DELETE api/<ClientController>/5
        [HttpDelete]
        public void Delete([FromForm] int id)
        {
            Client deleteclient = dbcontext.Clients.FirstOrDefault(p => p.Id == id);
            dbcontext.Clients.Remove(deleteclient);
            dbcontext.SaveChanges();
        }
    }
}
