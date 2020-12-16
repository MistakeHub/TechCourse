using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.InterTech;

namespace BackEnd.Models.Inizialization
{
    public class TechData
    {
        public static void InizializationAddress(TechDbContext context)
        {

            List<Address> addresses=new List<Address>()
            {
                new Address(){  Apartament = 32,Home = "Home1", Street = "street1"},
                new Address(){  Apartament = 33,Home = "Home2", Street = "street2"},
                new Address(){  Apartament = 34,Home = "Home3", Street = "street3"},
                new Address(){  Apartament = 35,Home = "Home4", Street = "street4"},
                new Address(){  Apartament = 36,Home = "Home5", Street = "street5"},
                new Address(){  Apartament = 37,Home = "Home6", Street = "street6"},


            };

            context.RemoveRange(context.Addresses);
            context.Addresses.AddRange(addresses);
            context.SaveChanges();


        }
    }
}
