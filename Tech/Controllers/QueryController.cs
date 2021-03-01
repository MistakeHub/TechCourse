using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.InterTech;
using BackEnd.Models;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            int idClient = dbcontext.Autos.Include(p=>p.Person).FirstOrDefault(p => p.RegNumer == regnumber).Person.Id;
            
            List<ClientViewModel> viewModel = dbcontext.Persons.Include(p=>p.Address).Where(d=>d.Id==idClient).Select(p => new ClientViewModel() { id = p.Id, SurnamePerson = p.SurnameNP,TitleAddress =p.Address.Street+", "+ p.Address.Home + ", " + p.Address.Apartament + ", " }).ToList();
            return viewModel;
        }

        [HttpGet("Query2/{surname}")]

        public List<AutoViewModel> Get2(string surname)
        {
            int idPerson = dbcontext.Persons.FirstOrDefault(p => p.SurnameNP == surname).Id;
            List<AutoViewModel> viewModel = dbcontext.Autos.Where(d => d.Person.Id == idPerson).Select(p => new AutoViewModel(){Id=p.Id, Brand = p.Brand.TitleBrand, DateStart = p.DateStart}).ToList();
            return viewModel;
        }

        [HttpGet("Query3/{surname}")]
        public AutoViewModel Get3(string surname)
        {
            Person client = dbcontext.Persons.FirstOrDefault(p=>p.SurnameNP==surname);
            var breaks = dbcontext.RequestForFixArchives.Include(p=>p.Client).ThenInclude(p=>p.Person).FirstOrDefault(p =>
                p.Client.Person.Id == client.Id).Breaks;
            return new AutoViewModel(){ Person = client.SurnameNP, Breaks = breaks };
        }


        [HttpGet("Query4/{surname}/{breaks}")]
        public FixRequestViewModel Get4(string surname,string breaks )
        {
            RequestForFixArchive request= dbcontext.RequestForFixArchives.Include(p=>p.Client).ThenInclude(p=>p.Person).Include(p=>p.Auto).Include(p=>p.Enroller).ThenInclude(p=>p.Person).Include(p=>p.Enroller).Include(p=>p.Auto).ThenInclude(p=>p.Break).FirstOrDefault(p => p.Client.Person.SurnameNP == surname  && p.Breaks == breaks);
            return new FixRequestViewModel() { Enroller =request.Enroller.Person.SurnameNP, Daterequest =request.Daterequest, DateEnd = request.DateEnd};
        }


        [HttpGet("Query5/{breaks}")]
        public List<ClientViewModel> Get5( string breaks)
        {
 
            return dbcontext.Requests.Where(p => p.Breaks == breaks).Select(p => new ClientViewModel() { SurnamePerson = dbcontext.Persons.FirstOrDefault(d => d.Id == dbcontext.Clients.FirstOrDefault(c => c.Id == p.Client.Id).Person.Id).SurnameNP }).ToList(); ;
        }

        [HttpGet("Query6/{auto}")]
        public IQueryable Get6( string auto)
        {
            var Auto = dbcontext.Brands.FirstOrDefault(d => d.TitleBrand == auto).TitleBrand;
            var Group = dbcontext.Autos.Where(d => dbcontext.Brands.FirstOrDefault(c=>c.id==d.Brand.id).TitleBrand == Auto).GroupBy(c => c.Break.BreakName).Select(p=>new {breaks=p.Key, count=p.Count()});
            return Group;
        }


        [HttpGet("Query7")]
        public IQueryable Get7()
        {
            var groups = dbcontext.Enrollers.GroupBy(u=>u.Specialty.Id).Select(g=>new { dbcontext.Specialties.FirstOrDefault(p => p.Id == g.Key).TitleSpec, Count =g.Count()});

            return groups;
        }

        [HttpGet("Reference")]
        public Reference Get8()
        {
            return new Reference(){Countauto = dbcontext.Autos.Count(), NotBusyEnroller = dbcontext.Enrollers.Count(x=>dbcontext.Statuses.FirstOrDefault(d=>x.Status.Id==d.Id).status=="Свободен")};

        }

        [HttpGet("Receipt")]
        public Receipt Get9()
        {
          
        


            return new Receipt()
            {
                CountCompleted = dbcontext.RequestForFixArchives.Count(),
                Sum = dbcontext.RequestForFixArchives.Sum(p => p.PriceBreak),
                AutoNotCompleted = string.Join(',', dbcontext.Requests.Select(d => new { auto = dbcontext.Brands.FirstOrDefault(c => c.id == dbcontext.Autos.FirstOrDefault(p => p.Id == d.Auto.Id).Brand.id).Model, })),
                AutoCompleted = string.Join(',',
                    dbcontext.RequestForFixArchives.Select(d => new
                    {
                        auto = d.Auto,
                        time = d.DateEnd.Subtract(d.Daterequest).Days+"(в днях)",
                        breaks = d.Breaks
                    }))

            }; 
        }

    }
}
