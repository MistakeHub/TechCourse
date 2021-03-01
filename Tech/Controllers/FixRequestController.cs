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


            

           return dbContext.Requests.Select(p=> new FixRequestViewModel(){Id = p.Id,Client =p.Client.Person.SurnameNP , Enroller 
                = p.Enroller.Person.SurnameNP,
                Auto = p.Auto.Brand.TitleBrand+", "+ p.Auto.Brand.Model, 
          
            DateEnd = p.DateEnd,Daterequest = p.Daterequest, StatusReady = p.StatusReady, PriceBreak = p.PriceBreak}).ToList();
        }



        // POST api/<FixRequestController>
        [HttpPost]
        public void Post([FromForm] int client, [FromForm] int enroller, [FromForm] string regnumber, [FromForm] DateTime datestart, [FromForm] DateTime dateEnd )
        {

            Auto newAuto = dbContext.Autos.Include(p=>p.Break).Include(p=>p.Brand).FirstOrDefault(p => p.RegNumer == regnumber);
            Enroller newEnroller = dbContext.Enrollers.FirstOrDefault(p => p.Id == enroller);
            newEnroller.Status = dbContext.Statuses.FirstOrDefault(p => p.status == "Занят");
           
            
            dbContext.Enrollers.Update(newEnroller);
            dbContext.SaveChanges();

            RequestForFix newRequestForFix = new RequestForFix();
            

           newRequestForFix.Auto = newAuto;
           newRequestForFix.Client = dbContext.Clients.FirstOrDefault(p => p.Id == client);
           newRequestForFix.Enroller = newEnroller;
           newRequestForFix.Daterequest = datestart;
           newRequestForFix.DateEnd = dateEnd;
           newRequestForFix.PriceBreak += newAuto.Break.Price;
           newRequestForFix.StatusReady = false;
           newRequestForFix.Breaks = string.Join(',', dbContext.Autos.FirstOrDefault(p => p.RegNumer == regnumber).Break.BreakName);
           dbContext.Requests.Add(newRequestForFix);

            dbContext.SaveChanges();


        }



         
        // DELETE api/<FixRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            RequestForFix request = dbContext.Requests.Include(p=>p.Enroller).ThenInclude(p=>p.Status).Include(p=>p.Auto).Include(p=>p.Client).ThenInclude(p=>p.Person).FirstOrDefault(p => p.Id == id);

            request.StatusReady = true;
            Enroller newEnroller = dbContext.Enrollers.Include(p=>p.Person).FirstOrDefault(p => p.Id == request.Enroller.Id);
            newEnroller.Status.status= dbContext.Statuses.FirstOrDefault(p => p.status =="Свободен").status;
           

            dbContext.Enrollers.Update(newEnroller);
       
            dbContext.RequestForFixArchives.Add(new RequestForFixArchive()
                {
                    Request = request, Daterequest = request.Daterequest, DateEnd = request.DateEnd,
                    Auto = request.Auto, Client = request.Client, Enroller = request.Enroller,
                    PriceBreak = request.PriceBreak, StatusReady = request.StatusReady, Breaks = request.Breaks
            }
            );
         
            Auto auto = dbContext.Autos.Include(p=>p.Break).FirstOrDefault(p => p.Id == request.Auto.Id);
            dbContext.Autos.Remove(auto);
            dbContext.Requests.Remove(request);
            dbContext.Break.UpdateRange(dbContext.Break);
            dbContext.SaveChanges();

        }
         
        [HttpGet("Archive")]
        public List<RequestForFixArchive> Get2()
        {
            return dbContext.RequestForFixArchives.ToList();

        }
    
    }
}
