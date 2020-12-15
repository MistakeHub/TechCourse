using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech.Models
{
    public class RequestForFix
    {

      public int Id { get; set; }
      public Client IdClient { get; set; }
      public  Enroller IdEnroller { get; set; }
      public Auto IdAuto { get; set; }
      public List<Break> Breaks { get; set; }
      public DateTime Daterequest { get; set; }
      public bool StatusReady { get; set; }
      public double PriceBreak { get; set; }
      public DateTime DateEnd { get; set; }

    }
}
