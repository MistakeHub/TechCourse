﻿using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string SurnameNP { get; set; }
        public string Passport { get; set; }

        public List<Auto> autos { get; set; }
    }
}
