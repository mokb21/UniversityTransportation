using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.DTO.Journey
{
    public class PassengerJourneyStation
    {
        public Guid PassengerId { get; set; }

        public Guid JourneyId { get; set; }

        public Guid StationId { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
