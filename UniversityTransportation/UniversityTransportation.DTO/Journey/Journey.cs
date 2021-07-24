using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.DTO.Journey
{
    public class Journey
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public bool IsAdditional { get; set; }
        public bool IsRequestable { get; set; }
        public bool IsRepeatable { get; set; }
        public bool IsStarted { get; set; }

        public string RepeatDays { get; set; }

        public Guid DriverId { get; set; }

        public List<JourneyStation> JourneyStations { get; set; }
    }
}
