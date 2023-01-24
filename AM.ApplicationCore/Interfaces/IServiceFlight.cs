using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        IEnumerable<DateTime> GetFlightDates(string destination);
        void ShowFlightDetailsWithLinq(Plane plane);
        void ShowFlightDetailsWithLambda(Plane plane);
        int ProgrammedFlightNumberWithLinq(DateTime startDate);
        int ProgrammedFlightNumberWithLambda(DateTime startDate);
        double DurationAverageWithLinq(string destination);
        double DurationAverageWithLambda(string destination);
        IEnumerable<Flight> OrderedDurationFlightsWithLinq();
        IEnumerable<Flight> OrderedDurationFlightsWithLambda();
        IEnumerable<Traveller> SeniorTravellersWithLinq(Flight flight);
        IEnumerable<Traveller> SeniorTravellersWithLambda(Flight flight);
        IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlightsWithLinq();
        IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlightsWithLmbda();
    }
}