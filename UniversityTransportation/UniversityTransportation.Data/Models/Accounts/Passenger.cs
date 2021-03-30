using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}