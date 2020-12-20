using System;

namespace BackEnd.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdAddress { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }

    }
}
