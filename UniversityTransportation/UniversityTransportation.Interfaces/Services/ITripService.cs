using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Trip;

namespace UniversityTransportation.Interfaces.Services
{
    public interface ITripService
    {
        Task<Trip> StartTripAsync(Guid journeyId);

        Task<Trip> EndTripAsync(Guid journeyId);
    }
}
