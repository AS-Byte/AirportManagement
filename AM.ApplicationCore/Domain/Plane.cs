using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        #region exemple 
        //    string nom;

        //    public string GetNom() { return nom; }
        //    public void SetNom(string value) { this.nom = value; }

        //    //prop + 2Tab: light version
        //    public string Nom{ get; set; }

        //    //propfull + 2Tab: full version qui permet de personnaliser le get&Set
        //    private int number;

        //    public int MyProperty
        //    {
        //        get { return number; }
        //        set { number = value; }
        //    }

        //    //propg+2tab: secure version, setter private
        //    public int Salary { get; private set; }
        #endregion
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> Flights { get; set; }

    }

    





}
