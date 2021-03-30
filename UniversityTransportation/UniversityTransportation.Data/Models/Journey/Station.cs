using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.Data.Models.Journey
{
    public class Station
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public virtual ICollection<JourneyStation> JourneyStations { get; set; }

        public virtual ICollection<PassengerJourneyStation> PassengerJourneyStations { get; set; }
    }
}