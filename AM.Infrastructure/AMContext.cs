
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore; //ORM: équivalent de hibernate en java
namespace AM.Infrastructure
{
    public class AMContext:DbContext //Classe générique qui offres des méthodes permettant de configurer l'ORM
    {
        public DbSet <Plane> Planes { get; set; }
        public DbSet <Flight> Flights { get; set; }
        public DbSet <Staff> Staff { get; set; }
        public DbSet <Passenger> Passengers { get; set; }

        //chaine de connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=AirportManagement;
                Integrated Security=true;MultipleActiveResultSets=true"
                );
        }
    }
}