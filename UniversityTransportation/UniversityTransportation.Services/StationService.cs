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
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<Station> AddStationAsync(Station station)
        {
            try
            {
                station.Id = Guid.NewGuid();
                station.CreateDate = DateTime.Now;
                var result = await _stationRepository.AddAsync(_mapper.Map<Station, Data.Models.Journey.Station>(station));
                return _mapper.Map<Data.Models.Journey.Station, Station>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(station)} could not be saved: {ex.Message}");
            }
        }

        public void DeleteStation(Guid Id)
        {
            try
            {
                _stationRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"could not delete entity: {ex.Message}");
            }
        }

        public List<Station> GetAllStations()
        {
            try
            {
                var results = _stationRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Journey.Station>, List<Station>>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public Station GetStation(Guid Id)
        {
            try
            {
                var results = _stationRepository.Get(Id);
                return _mapper.Map<Data.Models.Journey.Station, Station>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<Station> UpdateStationAsync(Station station)
        {
            try
            {
                station.LastUpdateDate = DateTime.Now;
                var result = await _stationRepository.UpdateAsync(_mapper.Map<Station, Data.Models.Journey.Station>(station));
                return _mapper.Map<Data.Models.Journey.Station, Station>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(station)} could not be saved: {ex.Message}");

            }
        }
    }
}