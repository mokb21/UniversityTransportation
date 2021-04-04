using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models;
using UniversityTransportation.DTO.Accounts;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IPassengerService
    {
        Task<Passenger> AddDPassengerToUserAsync(Passenger passenger, ApplicationUser user);
    }
}
