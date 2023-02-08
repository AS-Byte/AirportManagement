using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
       
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }

        public string Departure { get; set; }
        public string Destination { get; set; }

        //Propriétés de navigation

        [ForeignKey("Plane")] //changement du nom de la colonne de la foreign key dans la base
        public int Planefk { get; set; }
        //l'annotation [Key] permet de défnir une clé primaire
        public virtual Plane Plane { get; set; } // on ajouter virtual devant chaque propriété de navigation

        public ICollection<Passenger> Passengers { get; set; }

        public string AirlineLogo { get; set; }
    }
}
