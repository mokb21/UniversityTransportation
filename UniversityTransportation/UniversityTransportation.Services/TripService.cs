using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Accounts;
using UniversityTransportation.DTO.Trip;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Services.AutoMapper;

namespace UniversityTransportation.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<Trip> StartTripAsync(Guid journeyId)
        {
            try
            {
                var result = await _tripRepository.StartTripAsync(journeyId);
                return _mapper.Map<Data.Models.Trip.Trip, Trip>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(StartTripAsync)} could not start a trip: {ex.Message}");
            }
        }

        public async Task<Trip> EndTripAsync(Guid journeyId)
        {
            try
            {
                var result = await _tripRepository.EndTripAsync(journeyId);
                return _mapper.Map<Data.Models.Trip.Trip, Trip>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(EndTripAsync)} could not end a trip: {ex.Message}");
            }
        }

        public async Task<Passenger> AddPassengerToTripAsync(Guid journeyId, Guid qrCode)
        {
            try
            {
                var result = await _tripRepository.AddPassengerToTripAsync(journeyId, qrCode);
                return _mapper.Map<Data.Models.Accounts.Passenger, Passenger>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(AddPassengerToTripAsync)} could not add passenger to trip: {ex.Message}");
            }
        }
    }
}
