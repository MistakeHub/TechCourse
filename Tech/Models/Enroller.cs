namespace BackEnd.Models
{
    public class Enroller
    {
        public int Id { get; set; }
        public Specialty IdSpecialty { get; set; }
        public Person IdPerson { get; set; }
        public string Level { get; set; }
        public string PeriodWork { get; set; }
        public Status idStatus { get; set; }

    }
}
