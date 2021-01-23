using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Receipt
    {

        public int CountCompleted { get; set; }
        public double Sum { get; set; }
        public string AutoCompleted { get; set; }
        public string AutoNotCompleted { get; set; }
      
        public string Breaks { get; set; }


    }
}
