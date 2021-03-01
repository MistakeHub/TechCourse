using System;

namespace BackEnd.Models
{
    public class Client
    {
        public int Id { get; set; }
     
        public int PersonId { get; set; }
        public Person Person { get; set; }
       
        
        public string PhoneNumber { get; set; }

    }
}
