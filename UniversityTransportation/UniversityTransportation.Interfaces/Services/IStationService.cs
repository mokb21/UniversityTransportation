using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Journey;
using UniversityTransportation.Models;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IStationService
    {
        List<Station> GetAllStations();

        Station GetStation(Guid Id);

        Task<Station> AddStationAsync(Station station);

        Task<Station> UpdateStationAsync(Station station);

        void DeleteStation(Guid Id);

        List<DetailedJourneyStationModel> GetDetailedStationsByJourneyId(Guid JourneyId);

    }
}
