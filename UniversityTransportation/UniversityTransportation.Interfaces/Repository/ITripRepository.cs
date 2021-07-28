using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Data.Models.Trip;

namespace UniversityTransportation.Interfaces.Repository
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<Trip> StartTripAsync(Guid journeyId);

        Task<Trip> EndTripAsync(Guid journeyId);

        Task<Passenger> AddPassengerToTripAsync(Guid journeyId, Guid qrCode);

        List<Passenger> GetTripPassengers(Guid journeyId);
    }
}
