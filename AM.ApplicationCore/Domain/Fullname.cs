using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    //[Owned] cette annotation remplace la config avec fluent API
    public class Fullname
    {
        
        [MinLength(3, ErrorMessage = "minimum 3"), MaxLength(25)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
