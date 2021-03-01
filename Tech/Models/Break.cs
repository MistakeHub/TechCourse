using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Break
    {
        
       
       public int Id { get; set; }
        public string BreakName { get; set; }
        public double Price { get; set; }
        public int PeriodBreak { get; set; }

    }
}
