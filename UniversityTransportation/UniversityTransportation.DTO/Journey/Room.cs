using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Accounts;

namespace UniversityTransportation.DTO.Journey
{
    public class Room
    {
        public Guid Id { get; set; }

        [Required]
        public Guid JourneyId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}
