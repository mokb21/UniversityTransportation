using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models;
using UniversityTransportation.DTO.Accounts;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Models;
using UniversityTransportation.Services.AutoMapper;

namespace UniversityTransportation.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<Passenger> AddDPassengerToUserAsync(Passenger passenger, ApplicationUser user)
        {
            try
            {
                //Add User to Passenger and QRCode after mapping
                var dataPassenger = _mapper.Map<Passenger, Data.Models.Accounts.Passenger>(passenger);
                dataPassenger.Id = Guid.NewGuid();
                dataPassenger.QRCode = Guid.NewGuid();
                dataPassenger.ApplicationUser = user;

                var result = await _passengerRepository.AddAsync(dataPassenger);

                return _mapper.Map<Data.Models.Accounts.Passenger, Passenger>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(passenger)} could not be saved: {ex.Message}");
            }
        }

        public void DeletePassenger(Guid Id)
        {
            try
            {
                _passengerRepository.Delete(Id);
            }
            catch (Exception ex)
            {

                throw new Exception($"could not delete entity: {ex.Message}");
            }
        }

        public List<Passenger> GetAllPassengers()
        {
            try
            {
                var results = _passengerRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Accounts.Passenger>, List<Passenger>>(results);
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public Passenger GetPassenger(Guid Id)
        {
            try
            {
                var results = _passengerRepository.Get(Id);
                return _mapper.Map<Data.Models.Accounts.Passenger, Passenger>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<int> VoteRoomAsync(VoteRoomModel voteRoom)
        {
            return await _passengerRepository.VoteRoomAsync(voteRoom);
        }
    }
}
