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
                //Add User to Passenger
                var dataPassenger = _mapper.Map<Passenger, Data.Models.Accounts.Passenger>(passenger);
                dataPassenger.ApplicationUser = user;

                var result = await _passengerRepository.AddAsync(dataPassenger);

                return _mapper.Map<Data.Models.Accounts.Passenger, Passenger>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(passenger)} could not be saved: {ex.Message}");
            }
        }
    }
}
