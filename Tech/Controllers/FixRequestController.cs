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


            

            return dbContext.Requests.Select(p=> new FixRequestViewModel(){Id = p.Id,Client =dbContext.Persons.FirstOrDefault(d=>d.Id==p.IdClient).SurnameNP, Enroller 
                = string.Join(",",dbContext.Enrollers.Select(d=> new EnrollerViewModel(){ Person = dbContext.Persons.FirstOrDefault(c=>c.Id==d.IdPerson).SurnameNP, }.Person).ToList()).ToString(),
                Auto  =string.Join("",dbContext.Autos.Select(d=>new AutoViewModel(){Brand =dbContext.Brands.FirstOrDefault(c=>c.id==d.IdBrand+3).TitleBrand+", "+ dbContext.Brands.FirstOrDefault(c => c.id == d.IdBrand + 3).Model}.Brand).ToList()).ToString(), 
                DateEnd = p.DateEnd,Daterequest = p.Daterequest, StatusReady = p.StatusReady, PriceBreak = p.PriceBreak}).ToList();
        }



        // POST api/<FixRequestController>
        [HttpPost]
        public void Post([FromForm] int client, [FromForm] int enroller, [FromForm] int auto, [FromForm] DateTime datestart, [FromForm] DateTime dateEnd)
        {

            Auto newAuto = dbContext.Autos.FirstOrDefault(p => p.Id == auto);
            Enroller newEnroller = dbContext.Enrollers.FirstOrDefault(p => p.Id == enroller);
            newEnroller.idStatus = dbContext.Statuses.FirstOrDefault(p => p.status == "Занят").Id;
           
            
            dbContext.Enrollers.Update(newEnroller);
            dbContext.Requests.Add(new RequestForFix()
            {
                IdAuto = newAuto.Id, IdClient = dbContext.Clients.FirstOrDefault(p => p.Id == client).Id,
                IdEnroller = newEnroller.Id, Daterequest = datestart,
                DateEnd = dateEnd, PriceBreak = newAuto.Breaks.Sum(p => p.Price),StatusReady = false,
            });
          
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
                PriceBreak = request.PriceBreak, StatusReady = request.StatusReady
            });

            dbContext.Requests.Remove(request);
            dbContext.SaveChanges();

        }
    }
}
