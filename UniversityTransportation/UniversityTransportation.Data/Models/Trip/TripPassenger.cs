using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;

namespace UniversityTransportation.Data.Models.Trip
{
    public class TripPassenger
    {
        public Guid TripId { get; set; }

        public virtual Trip Trip { get; set; }

        public Guid PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

    }
}
