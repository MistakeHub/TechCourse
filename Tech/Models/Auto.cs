using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Auto
    {
        public int Id { get; set; }
      
        public string RegNumer { get; set; }
        public string Color { get; set; }
        public int DateStart { get; set; }
        public Break Break { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Brand Brand { get; set; }

    }
}
