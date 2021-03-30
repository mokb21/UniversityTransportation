using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Journey;

namespace UniversityTransportation.Data.Models.Accounts
{
    public class Passenger
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string UniversityId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<PassengerJourneyStation> PassengerJourneyStations { get; set; }
    }
}