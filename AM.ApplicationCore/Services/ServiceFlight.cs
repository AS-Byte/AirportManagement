using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        //var globale
        public IList<Flight> Flights { get; set; } = new List<Flight>();
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {      
           IList<DateTime> dates = new List<DateTime>();
            //for (int i =0; i<Flights.Count; i++)
            //{
            //    if (Flights[i].Destination.Equals(destination))
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            // }


            //foreach (Flight f in Flights) {
            //    if (f.Destination.Equals(destination))
            //    {
            //        dates.Add(f.FlightDate);
            //    }
            //}

            // return dates; 
            var query = from f in Flights
                        where f.Destination == destination
                        select f.FlightDate;
            return query;
            
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where (f.FlightDate - startDate).TotalDays < 7 && (f.FlightDate > startDate)
                        select f;
                        return query.Count();   
                  
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights
                        where f.Plane== plane
                        select (f.FlightDate , f.Destination);
            foreach (var item in query)
            {
                Console.WriteLine(item.FlightDate + " " + item.Destination);

            }
        }
    }
    }

