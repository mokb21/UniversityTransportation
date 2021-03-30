using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.Data.Models.Accounts
{
    public class Driver
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid QRCode { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public string BusBuiltNumber { get; set; }

        [Required]
        public int NumberOfChairs { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
