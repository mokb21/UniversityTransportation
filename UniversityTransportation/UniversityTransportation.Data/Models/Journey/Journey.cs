using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Data.Models.Trip;

namespace UniversityTransportation.Data.Models.Journey
{
    public class Journey
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
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
        [MaxLength(200)]
        public string RepeatDays { get; set; }

        public Guid DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public virtual ICollection<JourneyStation> JourneyStations { get; set; }

        public virtual ICollection<PassengerJourneyStation> PassengerJourneyStations { get; set; }

        public virtual ICollection<Trip.Trip> Trips { get; set; }

        public virtual ICollection<RequestTrip> RequestTrips { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}
