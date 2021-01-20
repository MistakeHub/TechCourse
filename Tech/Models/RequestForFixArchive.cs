using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class RequestForFixArchive
    {

        public int Id { get; set; }
        public int idRequest { get; set; }
        public int IdClient { get; set; }
        public int IdEnroller { get; set; }
        public int IdAuto { get; set; }
        public string Breaks { get; set; }
        public DateTime Daterequest { get; set; }
        public bool StatusReady { get; set; }
        public double PriceBreak { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
