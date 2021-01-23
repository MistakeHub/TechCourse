using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.InterTech;
using BackEnd.Models;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

        [HttpGet("Query3/{surname}")]
        public AutoViewModel Get3(string surname)
        {
            Person client = dbcontext.Persons.FirstOrDefault(p=>p.SurnameNP==surname);
            var breaks = dbcontext.RequestForFixArchives.FirstOrDefault(p =>
                dbcontext.Clients.FirstOrDefault(d => d.Id == p.IdClient).IdPerson == client.Id).Breaks;
            return new AutoViewModel(){ Person = client.SurnameNP, Breaks = breaks };
        }


        [HttpGet("Query4/{surname}/{breaks}")]
        public FixRequestViewModel Get4(string surname,string breaks )
        {
            RequestForFixArchive request= dbcontext.RequestForFixArchives.FirstOrDefault(p => p.IdClient == dbcontext.Clients.FirstOrDefault(d=>d.IdPerson==dbcontext.Persons.FirstOrDefault(c=>c.SurnameNP==surname).Id).Id && p.Breaks == breaks);
            return new FixRequestViewModel() { Enroller =dbcontext.Persons.FirstOrDefault(p=>p.Id==dbcontext.Enrollers.FirstOrDefault(d=>d.Id==request.IdEnroller).IdPerson).SurnameNP, Daterequest =request.Daterequest, DateEnd = request.DateEnd};
        }


        [HttpGet("Query5/{breaks}")]
        public List<ClientViewModel> Get5( string breaks)
        {
 
            return dbcontext.Requests.Where(p => p.Breaks == breaks).Select(p => new ClientViewModel() { SurnamePerson = dbcontext.Persons.FirstOrDefault(d => d.Id == dbcontext.Clients.FirstOrDefault(c => c.Id == p.IdClient).IdPerson).SurnameNP }).ToList(); ;
        }

        [HttpGet("Query6/{auto}")]
        public IQueryable Get6( string auto)
        {
            var Auto = dbcontext.Brands.FirstOrDefault(d => d.TitleBrand == auto).TitleBrand;
            var Group = dbcontext.Autos.Where(d => dbcontext.Brands.FirstOrDefault(c=>c.id==d.IdBrand).TitleBrand == Auto).GroupBy(c => c.Breaks.BreakName).Select(p=>new {breaks=p.Key, count=p.Count()});
            return Group;
        }


        [HttpGet("Query7")]
        public IQueryable Get7()
        {
            var groups = dbcontext.Enrollers.GroupBy(u=>u.IdSpecialty).Select(g=>new { dbcontext.Specialties.FirstOrDefault(p => p.Id == g.Key).TitleSpec, Count =g.Count()});

            return groups;
        }

        [HttpGet("Reference")]
        public Reference Get8()
        {
            return new Reference(){Countauto = dbcontext.Autos.Count(), NotBusyEnroller = dbcontext.Enrollers.Count(x=>dbcontext.Statuses.FirstOrDefault(d=>x.idStatus==d.Id).status=="Свободен")};

        }

        [HttpGet("Receipt")]
        public Receipt Get9()
        {
          
        


            return new Receipt()
            {
                CountCompleted = dbcontext.RequestForFixArchives.Count(),
                Sum = dbcontext.RequestForFixArchives.Sum(p => p.PriceBreak),
                AutoCompleted = string.Join(',', dbcontext.Requests.Select(d => new { auto = dbcontext.Brands.FirstOrDefault(c => c.id == dbcontext.Autos.FirstOrDefault(p => p.Id == d.IdAuto).IdBrand).Model, })),
                AutoNotCompleted = string.Join(',',
                    dbcontext.RequestForFixArchives.Select(d => new
                    {
                        auto = dbcontext.Brands.FirstOrDefault(c =>
                            c.id == dbcontext.Autos.FirstOrDefault(p => dbcontext.Brands.FirstOrDefault(a => a.id == p.IdBrand).Model == d.Auto).IdBrand).Model,
                        time = d.DateEnd - d.Daterequest,
                        breaks = d.Breaks
                    }))

            }; 
        }

    }
}
