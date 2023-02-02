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
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane> //l'interface qu'on vient d'implementer fait partie de fluent API
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(p => p.PlaneId);//
            builder.ToTable("MyPlanes");//on a changé le nom de la table
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");//on a ahangé le nom de la col
        }
    }
}
