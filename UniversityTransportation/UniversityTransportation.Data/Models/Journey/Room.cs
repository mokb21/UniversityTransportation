using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.Data.Models.Journey
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid JourneyId { get; set; }

        public virtual Journey Journey { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
