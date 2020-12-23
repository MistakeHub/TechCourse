using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ClientViewModel
    {

        public int id { get; set; }
        public string SurnamePerson { get; set; }
        public string TitleAddress { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }


    }
}
