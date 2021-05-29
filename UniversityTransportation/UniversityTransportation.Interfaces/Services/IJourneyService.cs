using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Journey;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IJourneyService
    {
        Task<Journey> AddJourneyAsync(Journey journey);

        void DeleteJourney(Guid Id);

        List<Journey> GetAllJourneys();

        List<Journey> GetJourneysByDriverId(Guid DriverId);

        Journey GetJourney(Guid Id);

        Task<Journey> UpdateJourneyAsync(Journey journey);

    }
}
