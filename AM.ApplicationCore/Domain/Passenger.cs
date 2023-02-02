using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key, StringLength(7)]
        public string PassportNumber { get; set; }
        public Fullname Fullname { get; set; }

        [DataType(DataType.Date), DisplayName("Date of Birth")]
        public DateTime BirthDate { get; set; }
        //
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        [Range(0, 8)]
        public int TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public ICollection<Flight> Flights { get; set; }

        //polymorphisme par signature
        public bool CheckProfile(string firstName, string lastName)
        {
            return Fullname.FirstName.Equals(firstName) && Fullname.LastName.Equals(lastName);
        }
        public bool CheckProfile(string firstName, string lastName,string email)
        {

            //return FirstName.Equals(firstName) && LastName.Equals(lastName) && EmailAddress.Equals(email);
            return CheckProfile(firstName, lastName) && EmailAddress.Equals(email);
            
        }
        public bool Login(string firstName, string lastName, string email=null)
        {
            if (email!=null) 
                return    CheckProfile(firstName, lastName, email); 
            return CheckProfile(firstName,lastName);
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am Passenger");
        }
    }
}