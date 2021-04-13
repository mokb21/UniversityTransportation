using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Trip;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Services.AutoMapper;

namespace UniversityTransportation.Services
{
    public class RequestTripService : IRequestTripService
    {
        private readonly IRequestTripRepository _requestTripRepository;
        private readonly IMapper _mapper;

        public RequestTripService(IRequestTripRepository requestTripRepository)
        {
            _requestTripRepository = requestTripRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<RequestTrip> AddRequestTripAsync(RequestTrip requestTrip)
        {
            try
            {
                requestTrip.Id = Guid.NewGuid();
                requestTrip.RequestDate = DateTime.Now;

                var result = await _requestTripRepository.AddAsync(_mapper.Map<RequestTrip, Data.Models.Trip.RequestTrip>(requestTrip));
                return _mapper.Map<Data.Models.Trip.RequestTrip, RequestTrip>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(requestTrip)} could not be saved: {ex.Message}");
            }
        }

        public void DeleteRequestTrip(Guid Id)
        {
            try
            {
                _requestTripRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"could not delete entity: {ex.Message}");
            }
        }

        public List<RequestTrip> GetAllRequestTrips()
        {
            try
            {
                var results = _requestTripRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Trip.RequestTrip>, List<RequestTrip>>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public RequestTrip GetRequestTrip(Guid Id)
        {
            try
            {
                var results = _requestTripRepository.Get(Id);
                return _mapper.Map<Data.Models.Trip.RequestTrip, RequestTrip>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }
    }
}
