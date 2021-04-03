using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models;
using UniversityTransportation.DTO.Accounts;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IDriverService
    {
        Task<Driver> AddDriverToUserAsync(Driver driver, ApplicationUser user);
    }
}
