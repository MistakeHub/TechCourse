using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public int IdPerson { get; set; }
        public string RegNumer { get; set; }
        public string Color { get; set; }
        public int DateStart { get; set; }
        public Break Breaks { get; set; }

    }
}
