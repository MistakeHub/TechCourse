using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.ViewModels
{
    public class FixRequestViewModel
    {

        public int Id { get; set; }
        public string Client { get; set; }
        public string Enroller { get; set; }
        public string Auto { get; set; }

        public DateTime Daterequest { get; set; }
        public bool StatusReady { get; set; }
        public double PriceBreak { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
