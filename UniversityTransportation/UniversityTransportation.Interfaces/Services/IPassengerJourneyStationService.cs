using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Journey;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IPassengerJourneyStationService
    {
        PassengerJourneyStation GetPassengerJourneyStation(Guid PassengerId);

        List<PassengerJourneyStation> GetAllPassengerJourneyStation();

        Task<PassengerJourneyStation> AddPassengerJourneyStationAsync(PassengerJourneyStation passengerJourneyStation);

        Task<PassengerJourneyStation> UpdatePassengerJourneyStationAsync(PassengerJourneyStation passengerJourneyStation);
    }
}