using System;

namespace BackEnd.Models
{
    public class Client
    {
        public int Id { get; set; }
     
        public Person Person { get; set; }
        public Address Address { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }

    }
}
