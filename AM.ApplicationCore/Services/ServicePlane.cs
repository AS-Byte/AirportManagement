using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane//une classe impléente d'autres classes et des interfaces en meme temps, il faut déclarer les classes à implémenter puis les interfaces
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork){        }

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3560);
        }

        public IEnumerable<Flight> GetFlights()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Passenger> GetPassenger(Plane p)
        {
            return p.Flights.SelectMany(p => p.Passengers);

        }
        public bool IsAvailablePlane(int n)
        {
            throw new NotImplementedException();
        }
    }
}
