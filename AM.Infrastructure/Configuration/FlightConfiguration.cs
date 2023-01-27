using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //Renommer la table associative de la relation many-to-many entre la classe Flight et la classe Passenger            
            builder.HasMany(p => p.Passengers)
                .WithMany(p => p.Flights).UsingEntity(j => j.ToTable("volsVoyageurs"));
            //Renommer la clé étrangère de la relation one-to-many entre la classe Flight et la classe Plane
            builder.HasOne(p => p.Plane)
                .WithMany(p => p.Flights);
              //  .HasForeignKey(p => p.Planefk);// renommer le clé étran 

        }
    }
}
