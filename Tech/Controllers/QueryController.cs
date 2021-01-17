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
    public class QueryController : ControllerBase
    {

        private TechDbContext dbcontext;

        public QueryController(TechDbContext _dbContext)
        {
            dbcontext = _dbContext;

        }
        // GET: api/<QueryController>
        [HttpGet("Query1/{regnumber}")]
     
        public List<ClientViewModel> Get(string regnumber )
        {

            int idClient = dbcontext.Autos.FirstOrDefault(p => p.RegNumer == regnumber).IdPerson-5;
            List<ClientViewModel> viewModel = dbcontext.Clients.Where(d=>d.IdPerson==idClient).Select(p => new ClientViewModel() { id = p.Id, PhoneNumber = p.PhoneNumber, Date = p.DateBirth, SurnamePerson = dbcontext.Persons.FirstOrDefault(c => c.Id == p.IdPerson).SurnameNP, TitleAddress = dbcontext.Addresses.FirstOrDefault(d => d.Id == p.IdAddress).Street + ", " + dbcontext.Addresses.FirstOrDefault(d => d.Id == p.IdAddress).Home + "," + dbcontext.Addresses.FirstOrDefault(d => d.Id == p.IdAddress).Apartament }).ToList();
            return viewModel;
        }

        [HttpGet("Query2/{surname}")]

        public List<AutoViewModel> Get2(string surname)
        {

            int idPerson = dbcontext.Persons.FirstOrDefault(p => p.SurnameNP == surname).Id;
            List<AutoViewModel> viewModel = dbcontext.Autos.Where(d => d.IdPerson == idPerson).Select(p => new AutoViewModel(){Id=p.Id,Brand = dbcontext.Brands.FirstOrDefault(d=>d.id==p.IdBrand).TitleBrand,  DateStart = p.DateStart}).ToList();
            return viewModel;
        }

    }
}
