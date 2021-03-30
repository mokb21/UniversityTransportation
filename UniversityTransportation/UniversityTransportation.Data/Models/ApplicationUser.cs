using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;

namespace UniversityTransportation.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public byte Role { get; set; }

        public Guid? PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }

        public Guid? DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
