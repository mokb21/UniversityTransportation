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
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<Driver> AddDriverToUserAsync(Driver driver, ApplicationUser user)
        {
            try
            {
                //Add User to Driver and QRCode after mapping
                var dataDriver = _mapper.Map<Driver, Data.Models.Accounts.Driver>(driver);
                dataDriver.Id = Guid.NewGuid();
                dataDriver.QRCode = Guid.NewGuid();
                dataDriver.ApplicationUser = user;

                var result = await _driverRepository.AddAsync(dataDriver);

                return _mapper.Map<Data.Models.Accounts.Driver, Driver>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(driver)} could not be saved: {ex.Message}");
            }
        }

        public List<Driver> GetAllDrivers()
        {
            try
            {
                var results = _driverRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Accounts.Driver>, List<Driver>>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public Driver GetDriver(Guid Id)
        {
            try
            {
                var results = _driverRepository.Get(Id);
                return _mapper.Map<Data.Models.Accounts.Driver, Driver>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public void DeleteDriver(Guid Id)
        {
            try
            {
                _driverRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"could not delete entity: {ex.Message}");
            }
        }
    }
}
