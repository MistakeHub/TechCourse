using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.ViewModels
{
    public class EnrollerViewModel
    {

        public int Id { get; set; }
        public string Specialty { get; set; }
        public string Person { get; set; }
        public string Level { get; set; }
        public string PeriodWork { get; set; }
        public string Status { get; set; }
    }
}
