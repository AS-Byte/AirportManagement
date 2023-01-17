using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
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
        public int ProgrammedFlightNumberWithLinq (DateTime startDate)
        {
            var query = from f in Flights
                        where (f.FlightDate - startDate).TotalDays < 7 && (f.FlightDate > startDate)
                        select f;
                        return query.Count();   

        }
        public int ProgrammedFlightNumberWithLambda(DateTime startDate)
        {
            return Flights.Where(f => (f.FlightDate - startDate).TotalDays < 7).Count();
        }
        public void ShowFlightDetailsWithLinq(Plane plane)
        {
            var query = from f in Flights
                        where f.Plane== plane
                        select (f.FlightDate , f.Destination);
            foreach (var item in query)
            {
                Console.WriteLine(item.FlightDate + " " + item.Destination);
            }
        }
        public void ShowFlightDetailsWithLambda(Plane plane)
        {
            var Lambda = Flights.Where(f => (f.Plane == plane)).
                Select(f => new { f.FlightDate, f.Destination });
            foreach (var f in Lambda)
            {
                Console.WriteLine(f.FlightDate + " " + f.Destination);
            }
        }
        public double DurationAverageWithLinq(string destination)
        {
            var query = from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDuration;
            return query.Average();
        }
        public double DurationAverageWithLambda(string destination)
        {
            return Flights.Where(f=>(f.Destination== destination))
                .Average(f=>f.EstimatedDuration);   
        }

        public IEnumerable<Flight> OrderedDurationFlightsWithLinq()
        {
            var query = from f in Flights
                        orderby f.EstimatedDuration descending
                        select f;
            return query;
        }
        public IEnumerable<Flight> OrderedDurationFlightsWithLambda()
        {
            return Flights.OrderByDescending(f=>(f.EstimatedDuration));
        }

        public IEnumerable<Traveller> SeniorTravellersWithLinq(Flight flight)
        {
            var query = from p in flight.Passengers.OfType<Traveller>() 
                        orderby p.BirthDate
                        select p;
                        
            return query.Take(3);
        }

        public IEnumerable<Traveller> SeniorTravellersWithLambda(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>().OrderBy(f=>f.BirthDate).Take(3);
        }
    }
}