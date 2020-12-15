using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tech.Models;

namespace Tech.InterTech
{
    public class TechDbContext:DbContext
    {
        public TechDbContext(DbContextOptions<TechDbContext> contextOptions) : base(contextOptions) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Break> Breaks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Enroller> Enrollers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RequestForFix> Requests { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
