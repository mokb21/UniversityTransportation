﻿using System;
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

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }

        public Guid? QRCode { get; set; }

        public string BusBuiltNumber { get; set; }

        public int NumberOfChairs { get; set; }

        public byte[] Image { get; set; }
    }
}
