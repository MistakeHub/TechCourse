using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class RequestForFix
    {

      public int Id { get; set; }
    
      public string Breaks { get; set; }
      public DateTime Daterequest { get; set; }
      public bool StatusReady { get; set; }
      public double PriceBreak { get; set; }
      public DateTime DateEnd { get; set; }

      public Client Client { get; set; }
      public Enroller Enroller { get; set; }
      public Auto Auto { get; set; }

    }
}
