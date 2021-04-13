using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Trip;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IRequestTripService
    {
        Task<RequestTrip> AddRequestTripAsync(RequestTrip requestTrip);
        void DeleteRequestTrip(Guid Id);
        List<RequestTrip> GetAllRequestTrips();
        RequestTrip GetRequestTrip(Guid Id);
    }
}
