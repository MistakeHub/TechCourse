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
    public class FixRequestController : ControllerBase
    {
        // GET: api/<FixRequestController>
        private TechDbContext dbContext;

        public FixRequestController(TechDbContext db)
        {
            dbContext = db;

        }
        [HttpGet]
        public List<FixRequestViewModel> Get()
        {


            

            return dbContext.Requests.Select(p=> new FixRequestViewModel(){Id = p.Id,Client =dbContext.Persons.FirstOrDefault(d=>d.Id==dbContext.Clients.FirstOrDefault(c=>c.Id==p.IdClient).IdPerson).SurnameNP , Enroller 
                = dbContext.Persons.FirstOrDefault(d => d.Id == dbContext.Enrollers.FirstOrDefault(c => c.Id == p.IdEnroller).IdPerson).SurnameNP,
                Auto = dbContext.Brands.FirstOrDefault(d => d.id == dbContext.Autos.FirstOrDefault(c => c.Id == p.IdAuto).IdBrand).TitleBrand+", "+ dbContext.Brands.FirstOrDefault(d => d.id == dbContext.Autos.FirstOrDefault(c => c.Id == p.IdAuto).IdBrand).Model, 
                DateEnd = p.DateEnd,Daterequest = p.Daterequest, StatusReady = p.StatusReady, PriceBreak = p.PriceBreak}).ToList();
        }



        // POST api/<FixRequestController>
        [HttpPost]
        public void Post([FromForm] int client, [FromForm] int enroller, [FromForm] string regnumber, [FromForm] DateTime datestart, [FromForm] DateTime dateEnd )
        {

            Auto newAuto = dbContext.Autos.Include(p=>p.Breaks).FirstOrDefault(p => p.RegNumer == regnumber);
            Enroller newEnroller = dbContext.Enrollers.FirstOrDefault(p => p.Id == enroller);
            newEnroller.idStatus = dbContext.Statuses.FirstOrDefault(p => p.status == "Занят").Id;
           
            
            dbContext.Enrollers.Update(newEnroller);
            dbContext.SaveChanges();

            RequestForFix newRequestForFix = new RequestForFix();
            

           newRequestForFix.IdAuto = newAuto.Id;
           newRequestForFix.IdClient = dbContext.Clients.FirstOrDefault(p => p.Id == client).Id;
           newRequestForFix.IdEnroller = newEnroller.Id;
           newRequestForFix.Daterequest = datestart;
           newRequestForFix.DateEnd = dateEnd;
           newRequestForFix.PriceBreak += newAuto.Breaks.Price;
           newRequestForFix.StatusReady = false;
           newRequestForFix.Breaks = string.Join(',', dbContext.Autos.FirstOrDefault(p => p.RegNumer == regnumber).Breaks.BreakName);
           dbContext.Requests.Add(newRequestForFix);

            dbContext.SaveChanges();


        }

        
        

        // DELETE api/<FixRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            RequestForFix request = dbContext.Requests.FirstOrDefault(p => p.Id == id);

            request.StatusReady = true;
            Enroller newEnroller = dbContext.Enrollers.FirstOrDefault(p => p.Id == request.IdEnroller);
            newEnroller.idStatus = dbContext.Statuses.FirstOrDefault(p => p.status =="Свободен").Id;
           

            dbContext.Enrollers.Update(newEnroller);
         
            dbContext.RequestForFixArchives.Add(new RequestForFixArchive()
                {
                    idRequest = request.Id, Daterequest = request.Daterequest, DateEnd = request.DateEnd,
                    IdAuto = request.IdAuto, IdClient = request.IdClient, IdEnroller = request.IdEnroller,
                    PriceBreak = request.PriceBreak, StatusReady = request.StatusReady, Breaks = request.Breaks,Auto = string.Join(',',dbContext.Brands.FirstOrDefault(c=>dbContext.Autos.FirstOrDefault(d => d.Id == request.IdAuto).IdBrand==c.id).Model), Client =  string.Join(',', dbContext.Persons.FirstOrDefault(c => dbContext.Clients.FirstOrDefault(d => d.Id == request.IdClient).IdPerson == c.Id).SurnameNP), Enroller = string.Join(',', dbContext.Persons.FirstOrDefault(c => dbContext.Enrollers.FirstOrDefault(d => d.Id == request.IdEnroller).IdPerson == c.Id).SurnameNP), 
            }
            );

            Auto auto = dbContext.Autos.FirstOrDefault(p => p.Id == request.IdAuto);
            dbContext.Autos.Remove(auto);
            dbContext.Requests.Remove(request);
            dbContext.Breaks.UpdateRange(dbContext.Breaks);
            dbContext.SaveChanges();

        }

        [HttpGet("Archive")]
        public List<RequestForFixArchive> Get2()
        {
            return dbContext.RequestForFixArchives.ToList();

        }
    }
}
