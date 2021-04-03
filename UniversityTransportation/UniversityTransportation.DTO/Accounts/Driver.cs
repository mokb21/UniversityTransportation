using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.DTO.Accounts
{
    public class Driver
    {
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }

        public Guid? QRCode { get; set; }

        [Required]
        public string BusBuiltNumber { get; set; }

        [Required]
        public int NumberOfChairs { get; set; }

        public byte[] Image { get; set; }
    }
}
