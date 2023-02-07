
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore; //ORM: équivalent de hibernate en java
namespace AM.Infrastructure
{
    public class AMContext:DbContext //Classe générique qui offres des méthodes permettant de configurer l'ORM
    {
        public DbSet <Plane> Planes { get; set; }
        public DbSet <Flight> Flights { get; set; }
        public DbSet <Staff> Staff { get; set; }
        public DbSet <Passenger> Passengers { get; set; }

        // vu que nous avons ajoute 2 nouvelles entité: reservation et Ticket, il faut ajouter leurs dbset pour générer les tables dans la base
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> Reservations { get; set; }


        //chaine de connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=AirportManagement;
                Integrated Security=true;MultipleActiveResultSets=true"
                );
        }
        //Classes de configuration définies avec Fluent API, le code ci dessous va assurer la prise en compte des modifs 
        protected override void OnModelCreating(ModelBuilder modelBuilder) //cette methode concerne les paramétrages via fluent API
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration()); //appel de la méthode de config externe
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            // Ce qui suit remplace la création d'une classe config dans le dossier configuration
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.Fullname, full =>
            {
                full.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("Passfirstname");
                full.Property(f => f.LastName).HasColumnName("Passlastname").IsRequired();
            });
                //Le code ci après  permet de changer le contenu de la colonne discrim par un chiffre, TablePerHeritage                //.HasDiscriminator<int>("PassengerType")
                //.HasValue<Passenger>(0)
                //.HasValue<Traveller>(1)
                //.HasValue<Staff>(2);

            //COnfiguration de l'approche TablePerType
            modelBuilder.Entity<Staff>().ToTable("Staff");// 
            modelBuilder.Entity<Traveller>().ToTable("Traveller");

        }
        //Changement du nom de la colonne de datetime2 à date
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }   
    }
}