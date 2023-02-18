using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>//equivalent de IRepository dans spring
    {
        public IEnumerable<Passenger> GetPassenger(Plane p) ;
        public IEnumerable<Flight> GetFlights();
        public bool IsAvailablePlane(int n);
        public void DeletePlanes();
    }
}
      