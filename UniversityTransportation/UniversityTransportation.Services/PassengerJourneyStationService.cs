using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Journey;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Services.AutoMapper;

namespace UniversityTransportation.Services
{
    public class PassengerJourneyStationService : IPassengerJourneyStationService
    {
        private readonly IPassengerJourneyStationRepository _passengerJourneyStationRepository;
        private readonly IMapper _mapper;

        public PassengerJourneyStationService(IPassengerJourneyStationRepository passengerJourneyStationRepository)
        {
            _passengerJourneyStationRepository = passengerJourneyStationRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<PassengerJourneyStation> AddPassengerJourneyStationAsync(PassengerJourneyStation passengerJourneyStation)
        {
            try
            {
                passengerJourneyStation.RegistrationDate = DateTime.Now;
                var result = await _passengerJourneyStationRepository.AddAsync(_mapper.Map<PassengerJourneyStation, Data.Models.Journey.PassengerJourneyStation>(passengerJourneyStation));
                return _mapper.Map<Data.Models.Journey.PassengerJourneyStation, PassengerJourneyStation>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(passengerJourneyStation)} could not be saved: {ex.Message}");
            }
        }

        public List<PassengerJourneyStation> GetAllPassengerJourneyStation()
        {
            try
            {
                var results = _passengerJourneyStationRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Journey.PassengerJourneyStation>, List<PassengerJourneyStation>>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public PassengerJourneyStation GetPassengerJourneyStation(Guid PassengerId)
        {
            try
            {
                var result = _passengerJourneyStationRepository.Get(PassengerId);
                return _mapper.Map<Data.Models.Journey.PassengerJourneyStation, PassengerJourneyStation>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<PassengerJourneyStation> UpdatePassengerJourneyStationAsync(PassengerJourneyStation passengerJourneyStation)
        {
            try
            {
                var result = await _passengerJourneyStationRepository.UpdateAsync(_mapper.Map<PassengerJourneyStation, Data.Models.Journey.PassengerJourneyStation>(passengerJourneyStation));
                return _mapper.Map<Data.Models.Journey.PassengerJourneyStation, PassengerJourneyStation>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(passengerJourneyStation)} could not be saved: {ex.Message}");

            }
        }
    }
}
