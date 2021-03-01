namespace BackEnd.Models
{
    public class Enroller
    {
        public int Id { get; set; }
       
        public string Level { get; set; }
        public string PeriodWork { get; set; }
      

        public Person Person { get; set; }
        public Specialty Specialty { get; set; }
        public Status Status { get; set; }

    }
}
