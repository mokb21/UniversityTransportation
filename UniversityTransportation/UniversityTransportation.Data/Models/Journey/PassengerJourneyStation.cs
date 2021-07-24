using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;

namespace UniversityTransportation.Data.Models.Journey
{
    public class PassengerJourneyStation
    {
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public Guid JourneyId { get; set; }
        public Journey Journey { get; set; }

        public Guid StationId { get; set; }
        public Station Station { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
