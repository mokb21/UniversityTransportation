using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Journey;
using UniversityTransportation.Data.Models.Trip;

namespace UniversityTransportation.Data.Models.Accounts
{
    public class Passenger
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string UniversityId { get; set; }

        [Required]
        public Guid QRCode { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<PassengerJourneyStation> PassengerJourneyStations { get; set; }

        public virtual ICollection<TripPassenger> TripPassengers { get; set; }

        public virtual ICollection<RequestTrip> RequestTrips { get; set; }
    }
}