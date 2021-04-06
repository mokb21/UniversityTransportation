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
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;

        public JourneyService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<Journey> AddJourneyAsync(Journey journey)
        {
            try
            {
                journey.CreateDate = DateTime.Now;
                var result = await _journeyRepository.AddAsync(_mapper.Map<Journey, Data.Models.Journey.Journey>(journey));
                return _mapper.Map<Data.Models.Journey.Journey, Journey>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(journey)} could not be saved: {ex.Message}");
            }
        }

        public void DeleteJourney(Guid Id)
        {
            try
            {
                _journeyRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"could not delete entity: {ex.Message}");
            }
        }

        public List<Journey> GetAllJourneys()
        {
            try
            {
                var results = _journeyRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Journey.Journey>, List<Journey>>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public Journey GetJourney(Guid Id)
        {
            try
            {
                var results = _journeyRepository.Get(Id);
                return _mapper.Map<Data.Models.Journey.Journey, Journey>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<Journey> UpdateJourneyAsync(Journey journey)
        {
            try
            {
                journey.LastUpdateDate = DateTime.Now;
                var result = await _journeyRepository.UpdateAsync(_mapper.Map<Journey, Data.Models.Journey.Journey>(journey));
                return _mapper.Map<Data.Models.Journey.Journey, Journey>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(journey)} could not be saved: {ex.Message}");

            }
        }
    }
}
