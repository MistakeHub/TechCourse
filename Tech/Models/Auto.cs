namespace BackEnd.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public Brand IdBrand { get; set; }
        public Person IdPerson { get; set; }
        public string RegNumer { get; set; }
        public string Color { get; set; }
        public int DateStart { get; set; }
    }
}
