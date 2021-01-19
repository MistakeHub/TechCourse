using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public List<ClientViewModel> Get()
        {
            List<ClientViewModel> viewModel= dbcontext.Clients.Select(p=>new ClientViewModel(){ id=p.Id, PhoneNumber = p.PhoneNumber, Date = p.DateBirth, SurnamePerson = dbcontext.Persons.FirstOrDefault(c=>c.Id==p.IdPerson).SurnameNP, TitleAddress = dbcontext.Addresses.FirstOrDefault(d=>d.Id==p.IdAddress).Street +", "+ dbcontext.Addresses.FirstOrDefault(d=>d.Id==p.IdAddress).Home + ","+ dbcontext.Addresses.FirstOrDefault(d=>d.Id==p.IdAddress).Apartament }).ToList();
            return viewModel;
        }

        [HttpGet]
        [Route("Address")]
        public List<Address> GeAddresses()
        {
            return dbcontext.Addresses.ToList();

        }

        [HttpGet]
        [Route("Person")]
        public List<Person> GetPersons()
        {

            return dbcontext.Persons.ToList();

        }



        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromForm] string surnameNp, [FromForm] string passport, [FromForm]string street, [FromForm] string home, [FromForm] int apartametn, [FromForm]int year , [FromForm]int mounth, [FromForm]int day, [FromForm]string phonenumber)
        {
            Person newPerson=new Person(){SurnameNP = surnameNp, Passport = passport};
            Address newAddress= new Address() {Apartament = apartametn, Home = home, Street = street};
            dbcontext.Persons.Add(new Person() {SurnameNP = surnameNp, Passport = passport});
            dbcontext.Addresses.Add(new Address() {Apartament = apartametn, Home = home, Street = street});
            dbcontext.SaveChanges();
            Client newClient=new Client(){ IdPerson = dbcontext.Persons.FirstOrDefault(p=>p.Passport==passport).Id, IdAddress = dbcontext.Addresses.FirstOrDefault(p => p.Street== street && p.Apartament==apartametn && p.Home==home ).Id, DateBirth = new DateTime(year, mounth, day),PhoneNumber = phonenumber};
            dbcontext.Clients.Add(newClient);
            dbcontext.SaveChanges();
        }

        // PUT api/<ClientController>/5
        [HttpPut ("{id}")]
        public void Put( int id, [FromForm] string surname, [FromForm] string phonenumber, [FromForm] DateTime dateofbirth, [FromForm] string address )
        {
            Client changeClient = dbcontext.Clients.FirstOrDefault(p => p.Id == id);
            int idPerson= dbcontext.Persons.FirstOrDefault(p => p.Id==changeClient.IdPerson).Id;
            var a = address.Split(',').ToArray();
            Person changeperson = dbcontext.Persons.FirstOrDefault(p => p.Id==idPerson);
            changeperson.SurnameNP = surname;
            dbcontext.Persons.Update(changeperson);
            int idAddress = dbcontext.Addresses.FirstOrDefault(p => p.Id == changeClient.IdAddress).Id;
            
            Address changeAddress = dbcontext.Addresses.FirstOrDefault(p => p.Id == idAddress);
            
            changeAddress.Street = a[0];
            changeAddress.Home = a[1];
            changeAddress.Apartament = int.Parse(a[2]);
            changeClient.DateBirth = dateofbirth;
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
