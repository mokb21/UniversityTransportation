using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;

namespace UniversityTransportation.Data.Models.Trip
{
    public class RequestTrip
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public Guid JourneyId { get; set; }

        public virtual Journey.Journey Journey { get; set; }

        [Required]
        public DateTime TripDate { get; set; }

    }
}
