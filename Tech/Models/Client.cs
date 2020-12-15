using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Person IdPerson { get; set; }
        public Address IdAddress { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }

    }
}
