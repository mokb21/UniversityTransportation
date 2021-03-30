using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.Data.Models.Journey
{
    public class JourneyStation
    {
        public Guid JourneyId { get; set; }
        public Journey Journey { get; set; }

        public Guid StationId { get; set; }
        public Station Station { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}
