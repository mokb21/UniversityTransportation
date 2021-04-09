using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.DTO.Journey
{
    public class JourneyStation
    {
        public Guid JourneyId { get; set; }
        //public Journey Journey { get; set; }

        public Guid StationId { get; set; }
        //public Station Station { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}
