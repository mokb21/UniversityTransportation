using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Accounts;

namespace UniversityTransportation.DTO.Trip
{
    public class RequestTrip
    {
        public Guid Id { get; set; }

        [Required]
        public Guid PassengerId { get; set; }

        public Passenger Passenger { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public Guid JourneyId { get; set; }

        public Journey.Journey Journey { get; set; }

        [Required]
        public DateTime TripDate { get; set; }
    }
}
