using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.Data.Models.Trip
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid JourneyId { get; set; }

        public virtual Journey.Journey Journey { get; set; }

        public virtual ICollection<TripPassenger> TripPassengers { get; set; }

    }
}
